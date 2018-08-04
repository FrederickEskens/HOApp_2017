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
	[Register ("ImageMapViewController")]
	partial class ImageMapViewController
	{
		[Outlet]
		UIKit.UIImageView mapImage { get; set; }

		[Outlet]
		UIKit.UIScrollView scrMapScroll { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (mapImage != null) {
				mapImage.Dispose ();
				mapImage = null;
			}

			if (scrMapScroll != null) {
				scrMapScroll.Dispose ();
				scrMapScroll = null;
			}
		}
	}
}
