#region License

// Copyright (c) 2013, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This file is part of the ClearCanvas RIS/PACS open source project.
//
// The ClearCanvas RIS/PACS open source project is free software: you can
// redistribute it and/or modify it under the terms of the GNU General Public
// License as published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// The ClearCanvas RIS/PACS open source project is distributed in the hope that it
// will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
// Public License for more details.
//
// You should have received a copy of the GNU General Public License along with
// the ClearCanvas RIS/PACS open source project.  If not, see
// <http://www.gnu.org/licenses/>.

#endregion

using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.PatientAdmin;

namespace ClearCanvas.Ris.Application.Services.Admin.PatientAdmin
{
	[ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
	[ServiceImplementsContract(typeof(IPatientAdminService))]
	public class PatientAdminService : ApplicationServiceBase, IPatientAdminService
	{
		#region IPatientAdminService Members

		[ReadOperation]
		public LoadPatientProfileEditorFormDataResponse LoadPatientProfileEditorFormData(LoadPatientProfileEditorFormDataRequest request)
		{
			var workflowConfig = new WorkflowConfigurationReader();

			// ignore request
			// Sort the category from High to Low, then sort by name
			var categoryAssembler = new PatientNoteCategoryAssembler();
			IList<PatientNoteCategory> sortedCategoryList = CollectionUtils.Sort(
				PersistenceContext.GetBroker<IPatientNoteCategoryBroker>().FindAll(false),
				(x, y) => string.Compare(x.Name, y.Name));

			var response = new LoadPatientProfileEditorFormDataResponse
				{
					MrnAutoGenerated = workflowConfig.AutoGenerateMrn,
					AddressTypeChoices = EnumUtils.GetEnumValueList<AddressTypeEnum>(PersistenceContext),
					ContactPersonRelationshipChoices = EnumUtils.GetEnumValueList<ContactPersonRelationshipEnum>(PersistenceContext),
					ContactPersonTypeChoices = EnumUtils.GetEnumValueList<ContactPersonTypeEnum>(PersistenceContext),
					HealthcardAssigningAuthorityChoices = EnumUtils.GetEnumValueList<InsuranceAuthorityEnum>(PersistenceContext),
					MrnAssigningAuthorityChoices = EnumUtils.GetEnumValueList<InformationAuthorityEnum>(PersistenceContext),
					PrimaryLanguageChoices = EnumUtils.GetEnumValueList<SpokenLanguageEnum>(PersistenceContext),
					ReligionChoices = EnumUtils.GetEnumValueList<ReligionEnum>(PersistenceContext),
					SexChoices = EnumUtils.GetEnumValueList<SexEnum>(PersistenceContext),
					PhoneTypeChoices = (new SimplifiedPhoneTypeAssembler()).GetPatientPhoneTypeChoices(),
					NoteCategoryChoices = CollectionUtils.Map<PatientNoteCategory, PatientNoteCategorySummary, List<PatientNoteCategorySummary>>(sortedCategoryList,
						category => categoryAssembler.CreateNoteCategorySummary(category, this.PersistenceContext)),

					// Allergies related choices
					AllergenTypeChoices = EnumUtils.GetEnumValueList<AllergyAllergenTypeEnum>(PersistenceContext),
					AllergySeverityChoices = EnumUtils.GetEnumValueList<AllergySeverityEnum>(PersistenceContext),
					AllergySensitivityTypeChoices = EnumUtils.GetEnumValueList<AllergySensitivityTypeEnum>(PersistenceContext),
					PersonRelationshipTypeChoices = EnumUtils.GetEnumValueList<PersonRelationshipTypeEnum>(PersistenceContext)
				};

			return response;
		}


		[ReadOperation]
		[AuditRecorder(typeof(PatientAdminServiceRecorder.LoadPatientProfileForEdit))]
		public LoadPatientProfileForEditResponse LoadPatientProfileForEdit(LoadPatientProfileForEditRequest request)
		{
			var broker = PersistenceContext.GetBroker<IPatientProfileBroker>();

			var profile = broker.Load(request.PatientProfileRef);
			var assembler = new PatientProfileAssembler();
			return new LoadPatientProfileForEditResponse(profile.Patient.GetRef(), profile.GetRef(), assembler.CreatePatientProfileDetail(profile, PersistenceContext));
		}

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Patient.Update)]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.PatientProfile.Update)]
		[AuditRecorder(typeof(PatientAdminServiceRecorder.UpdatePatientProfile))]
		public UpdatePatientProfileResponse UpdatePatientProfile(UpdatePatientProfileRequest request)
		{
			var profile = PersistenceContext.Load<PatientProfile>(request.PatientProfileRef, EntityLoadFlags.CheckVersion);

			var updatePatient = Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Workflow.Patient.Update);
			var updateProfile = Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Workflow.PatientProfile.Update);

			UpdateHelper(profile, request.PatientDetail, updatePatient, updateProfile, false);

			LogicalHL7Event.PatientProfileModified.EnqueueEvents(profile);

			this.PersistenceContext.SynchState();

			var assembler = new PatientProfileAssembler();
			return new UpdatePatientProfileResponse(assembler.CreatePatientProfileSummary(profile, PersistenceContext));
		}

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Patient.Create)]
		[AuditRecorder(typeof(PatientAdminServiceRecorder.AddPatient))]
		public AddPatientResponse AddPatient(AddPatientRequest request)
		{
			var profile = new PatientProfile();

			// check if we should auto-generate the MRN
			var workflowConfig = new WorkflowConfigurationReader();
			if (workflowConfig.AutoGenerateMrn)
			{
				var authorities = PersistenceContext.GetBroker<IEnumBroker>().Load<InformationAuthorityEnum>(false);

				// just use the first Information Authority (there is typically only one in this case)
				profile.Mrn.AssigningAuthority = CollectionUtils.FirstElement(authorities);
				profile.Mrn.Id = PersistenceContext.GetBroker<IMrnBroker>().GetNext();
			}


			var patient = new Patient();
			patient.AddProfile(profile);

			UpdateHelper(profile, request.PatientDetail, true, true, !workflowConfig.AutoGenerateMrn);

			PersistenceContext.Lock(patient, DirtyState.New);

			LogicalHL7Event.PatientCreated.EnqueueEvents(profile);

			PersistenceContext.SynchState();

			var assembler = new PatientProfileAssembler();
			return new AddPatientResponse(assembler.CreatePatientProfileSummary(profile, PersistenceContext));
		}

		#endregion

		private void UpdateHelper(PatientProfile profile, PatientProfileDetail detail, bool updatePatient, bool updateProfile, bool updateMrn)
		{
			if (updatePatient)
			{
				var patient = profile.Patient;

				var noteAssembler = new PatientNoteAssembler();
				noteAssembler.Synchronize(patient, detail.Notes, CurrentUserStaff, PersistenceContext);

				var attachmentAssembler = new PatientAttachmentAssembler();
				attachmentAssembler.Synchronize(patient.Attachments, detail.Attachments, this.CurrentUserStaff, PersistenceContext);

				var allergyAssembler = new PatientAllergyAssembler();
				allergyAssembler.Synchronize(patient.Allergies, detail.Allergies, PersistenceContext);
			}

			if (updateProfile)
			{
				var assembler = new PatientProfileAssembler();
				assembler.UpdatePatientProfile(profile, detail, updateMrn, PersistenceContext);
			}
		}
	}
}
