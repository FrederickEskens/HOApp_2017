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
	[Register ("InfoViewController")]
	partial class InfoViewController
	{
		[Outlet]
		UIKit.UIButton btnCallEmergency { get; set; }

		[Outlet]
		UIKit.UIButton btnShowFirstAid { get; set; }

		[Outlet]
		UIKit.UILabel lblCallEmergency { get; set; }

		[Outlet]
		UIKit.UILabel lblDetailBar { get; set; }

		[Outlet]
		UIKit.UILabel lblDetailFirstAid { get; set; }

		[Outlet]
		UIKit.UILabel lblDetailInfoPoint { get; set; }

		[Outlet]
		UIKit.UILabel lblDetailWIFI { get; set; }

		[Outlet]
		UIKit.UILabel lblShowFirstAid { get; set; }

		[Outlet]
		UIKit.UILabel lblSubtitleBar { get; set; }

		[Outlet]
		UIKit.UILabel lblSubtitleFirstAid { get; set; }

		[Outlet]
		UIKit.UILabel lblSubtitleInfoPoint { get; set; }

		[Outlet]
		UIKit.UILabel lblSubtitleWIFI { get; set; }

		[Outlet]
		UIKit.UILabel lblTitle { get; set; }

		[Outlet]
		UIKit.UIScrollView scrMainScrollView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (scrMainScrollView != null) {
				scrMainScrollView.Dispose ();
				scrMainScrollView = null;
			}

			if (lblTitle != null) {
				lblTitle.Dispose ();
				lblTitle = null;
			}

			if (lblSubtitleInfoPoint != null) {
				lblSubtitleInfoPoint.Dispose ();
				lblSubtitleInfoPoint = null;
			}

			if (lblDetailInfoPoint != null) {
				lblDetailInfoPoint.Dispose ();
				lblDetailInfoPoint = null;
			}

			if (lblSubtitleBar != null) {
				lblSubtitleBar.Dispose ();
				lblSubtitleBar = null;
			}

			if (lblDetailBar != null) {
				lblDetailBar.Dispose ();
				lblDetailBar = null;
			}

			if (lblSubtitleWIFI != null) {
				lblSubtitleWIFI.Dispose ();
				lblSubtitleWIFI = null;
			}

			if (lblDetailWIFI != null) {
				lblDetailWIFI.Dispose ();
				lblDetailWIFI = null;
			}

			if (lblSubtitleFirstAid != null) {
				lblSubtitleFirstAid.Dispose ();
				lblSubtitleFirstAid = null;
			}

			if (lblDetailFirstAid != null) {
				lblDetailFirstAid.Dispose ();
				lblDetailFirstAid = null;
			}

			if (btnCallEmergency != null) {
				btnCallEmergency.Dispose ();
				btnCallEmergency = null;
			}

			if (lblCallEmergency != null) {
				lblCallEmergency.Dispose ();
				lblCallEmergency = null;
			}

			if (btnShowFirstAid != null) {
				btnShowFirstAid.Dispose ();
				btnShowFirstAid = null;
			}

			if (lblShowFirstAid != null) {
				lblShowFirstAid.Dispose ();
				lblShowFirstAid = null;
			}
		}
	}
}
