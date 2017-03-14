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
	[Register ("ContentViewController")]
	partial class ContentViewController
	{
		[Outlet]
		UIKit.UIButton btnOpenMenu { get; set; }

		[Outlet]
		UIKit.UIImageView imgBurger { get; set; }

		[Outlet]
		UIKit.UILabel lblViewTitle { get; set; }

		[Outlet]
		UIKit.UIView vwContent { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnOpenMenu != null) {
				btnOpenMenu.Dispose ();
				btnOpenMenu = null;
			}

			if (lblViewTitle != null) {
				lblViewTitle.Dispose ();
				lblViewTitle = null;
			}

			if (vwContent != null) {
				vwContent.Dispose ();
				vwContent = null;
			}

			if (imgBurger != null) {
				imgBurger.Dispose ();
				imgBurger = null;
			}
		}
	}
}
