#region License

// Copyright (c) 2013, ClearCanvas Inc.
// All rights reserved.
// http://www.ClearCanvas.ca
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

// This file is auto-generated by the Macro.Model.SqlServer.CodeGenerator project.

namespace Macro.ImageServer.Model
{
    using System;
    using System.Xml;
    using Macro.Enterprise.Core;
    using Macro.ImageServer.Enterprise;
    using Macro.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class DevicePreferredTransferSyntax: ServerEntity
    {
        #region Constructors
        public DevicePreferredTransferSyntax():base("DevicePreferredTransferSyntax")
        {}
        public DevicePreferredTransferSyntax(
             ServerEntityKey _deviceKey_
            ,ServerEntityKey _serverSopClassKey_
            ,ServerEntityKey _serverTransferSyntaxKey_
            ):base("DevicePreferredTransferSyntax")
        {
            DeviceKey = _deviceKey_;
            ServerSopClassKey = _serverSopClassKey_;
            ServerTransferSyntaxKey = _serverTransferSyntaxKey_;
        }
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="DevicePreferredTransferSyntax", ColumnName="DeviceGUID")]
        public ServerEntityKey DeviceKey
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="DevicePreferredTransferSyntax", ColumnName="ServerSopClassGUID")]
        public ServerEntityKey ServerSopClassKey
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="DevicePreferredTransferSyntax", ColumnName="ServerTransferSyntaxGUID")]
        public ServerEntityKey ServerTransferSyntaxKey
        { get; set; }
        #endregion

        #region Static Methods
        static public DevicePreferredTransferSyntax Load(ServerEntityKey key)
        {
            using (var read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public DevicePreferredTransferSyntax Load(IPersistenceContext read, ServerEntityKey key)
        {
            var broker = read.GetBroker<IDevicePreferredTransferSyntaxEntityBroker>();
            DevicePreferredTransferSyntax theObject = broker.Load(key);
            return theObject;
        }
        static public DevicePreferredTransferSyntax Insert(DevicePreferredTransferSyntax entity)
        {
            using (var update = PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
            {
                DevicePreferredTransferSyntax newEntity = Insert(update, entity);
                update.Commit();
                return newEntity;
            }
        }
        static public DevicePreferredTransferSyntax Insert(IUpdateContext update, DevicePreferredTransferSyntax entity)
        {
            var broker = update.GetBroker<IDevicePreferredTransferSyntaxEntityBroker>();
            var updateColumns = new DevicePreferredTransferSyntaxUpdateColumns();
            updateColumns.DeviceKey = entity.DeviceKey;
            updateColumns.ServerSopClassKey = entity.ServerSopClassKey;
            updateColumns.ServerTransferSyntaxKey = entity.ServerTransferSyntaxKey;
            DevicePreferredTransferSyntax newEntity = broker.Insert(updateColumns);
            return newEntity;
        }
        #endregion
    }
}