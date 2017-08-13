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
	[Register ("SongViewController")]
	partial class SongViewController
	{
		[Outlet]
		UIKit.UIImageView imgYearBadge { get; set; }

		[Outlet]
		UIKit.UILabel lblSongText { get; set; }

		[Outlet]
		UIKit.UILabel lblSubtitle { get; set; }

		[Outlet]
		UIKit.UILabel lblTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgYearBadge != null) {
				imgYearBadge.Dispose ();
				imgYearBadge = null;
			}

			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}

			if (lblSubtitle != null) {
				lblSubtitle.Dispose ();
				lblSubtitle = null;
			}

			if (lblSongText != null) {
				lblSongText.Dispose ();
				lblSongText = null;
			}
		}
	}
}
