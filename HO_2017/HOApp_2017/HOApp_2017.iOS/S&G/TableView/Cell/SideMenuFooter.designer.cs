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
	[Register ("SideMenuFooter")]
	partial class SideMenuFooter
	{
		[Outlet]
		UIKit.UIButton btnFB { get; set; }

		[Outlet]
		UIKit.UIButton btnInsta { get; set; }

		[Outlet]
		UIKit.UIButton btnTwitter { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnFB != null) {
				btnFB.Dispose ();
				btnFB = null;
			}

			if (btnInsta != null) {
				btnInsta.Dispose ();
				btnInsta = null;
			}

			if (btnTwitter != null) {
				btnTwitter.Dispose ();
				btnTwitter = null;
			}
		}
	}
}
