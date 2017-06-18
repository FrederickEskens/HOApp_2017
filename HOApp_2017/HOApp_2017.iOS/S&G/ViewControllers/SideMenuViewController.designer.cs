// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HOApp_2017.iOS
{
	[Register ("SideMenuViewController")]
	partial class SideMenuViewController
	{
		[Outlet]
		UIKit.UIButton btnIntro { get; set; }

		[Outlet]
		UIKit.UIButton btnProgramm { get; set; }

		[Outlet]
		UIKit.UITableView tblSideMenu { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnIntro != null) {
				btnIntro.Dispose ();
				btnIntro = null;
			}

			if (btnProgramm != null) {
				btnProgramm.Dispose ();
				btnProgramm = null;
			}

			if (tblSideMenu != null) {
				tblSideMenu.Dispose ();
				tblSideMenu = null;
			}
		}
	}
}
