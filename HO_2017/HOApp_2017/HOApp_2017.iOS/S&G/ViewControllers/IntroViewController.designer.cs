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
	[Register ("IntroViewController")]
	partial class IntroViewController
	{
		[Outlet]
		UIKit.UIImageView imgIntroTopImage { get; set; }

		[Outlet]
		UIKit.UILabel lblIntroSubTitle { get; set; }

		[Outlet]
		UIKit.UILabel lblIntroText { get; set; }

		[Outlet]
		UIKit.UILabel lblIntroTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgIntroTopImage != null) {
				imgIntroTopImage.Dispose ();
				imgIntroTopImage = null;
			}

			if (lblIntroText != null) {
				lblIntroText.Dispose ();
				lblIntroText = null;
			}

			if (lblIntroSubTitle != null) {
				lblIntroSubTitle.Dispose ();
				lblIntroSubTitle = null;
			}

			if (lblIntroTitle != null) {
				lblIntroTitle.Dispose ();
				lblIntroTitle = null;
			}
		}
	}
}
