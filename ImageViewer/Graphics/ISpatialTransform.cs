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

using System.Drawing;
using Macro.Desktop;

namespace Macro.ImageViewer.Graphics
{
	/// <summary>
	/// Defines a 2D spatial transformation.
	/// </summary>
	public interface ISpatialTransform : IMemorable
	{
		/// <summary>
		/// Gets or sets a value indicating that the object is flipped vertically
		/// (i.e. mirrored on the x-axis).
		/// </summary>
		bool FlipX { get; set; }

		/// <summary>
		/// Gets or sets a value indicating that the object is flipped horizontally
		/// (i.e. mirrored on the y-axis).
		/// </summary>
		bool FlipY { get; set; }

		/// <summary>
		/// Gets or sets the rotation.
		/// </summary>
		int RotationXY { get; set; }

		/// <summary>
		/// Gets or sets the scale.
		/// </summary>
		float Scale { get; set; }
		
		/// <summary>
		/// Gets or sets the translation in the x-direction.
		/// </summary>
		float TranslationX { get; set; }

		/// <summary>
		/// Gets or sets the translation in the y-direction.
		/// </summary>
		float TranslationY { get; set; }

		/// <summary>
		/// Gets or sets the center of rotation.
		/// </summary>
		/// <remarks>
		/// The point should be specified in terms of the coordinate system
		/// of the parent graphic, i.e. source coordinates.
		/// </remarks>
		PointF CenterOfRotationXY { get; set; }

		/// <summary>
		/// Gets the cumulative scale.
		/// </summary>
		/// <remarks>
		/// Gets the scale relative to the root of the scene graph.
		/// </remarks>
		float CumulativeScale { get; }
	}
}
