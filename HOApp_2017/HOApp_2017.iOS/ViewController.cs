using System;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using SidebarNavigation;
using UIKit;

namespace HOApp_2017.iOS
{
	public partial class ViewController : UIViewController
	{
		public SidebarController SidebarController { get; private set; }

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			var storyBoard = UIStoryboard.FromName("Main", null);
			SidebarController = new SidebarController(this, storyBoard.InstantiateViewController("content"), storyBoard.InstantiateViewController("menu"));
			SidebarController.MenuLocation = SidebarController.MenuLocations.Left;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }
	}
}

