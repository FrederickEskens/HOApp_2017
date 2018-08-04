// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HOApp_2017.iOS
{
	[Register ("ProgrammSingleCell")]
	partial class ProgrammSingleCell
	{
		[Outlet]
		UIKit.UILabel lblSubTitle { get; set; }

		[Outlet]
		UIKit.UILabel lblTimeFrame { get; set; }

		[Outlet]
		UIKit.UILabel lblTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblTimeFrame != null) {
				lblTimeFrame.Dispose ();
				lblTimeFrame = null;
			}

			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}

			if (lblSubTitle != null) {
				lblSubTitle.Dispose ();
				lblSubTitle = null;
			}
		}
	}
}
