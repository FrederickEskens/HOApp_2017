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
	[Register ("SideMenuTableViewCell")]
	partial class SideMenuTableViewCell
	{
		[Outlet]
		UIKit.UILabel lblMenuItemTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMenuItemTitle != null) {
				lblMenuItemTitle.Dispose ();
				lblMenuItemTitle = null;
			}
		}
	}
}
