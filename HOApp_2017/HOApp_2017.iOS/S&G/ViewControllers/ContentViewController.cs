// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using HOApp_2017.iOS.SG.ViewControllers.Base;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using SidebarNavigation;
using UIKit;

namespace HOApp_2017.iOS
{
	public partial class ContentViewController : BaseViewController
	{
		
		#region delegates

		#endregion

		#region variables
		Dictionary<int, BaseContentViewController> _viewControllerDicitonary;
		UIViewController _activeViewController;

        BaseContentViewController _introViewController;
		BaseContentViewController _programmViewController;
        BaseContentViewController _mapViewController;
        BaseContentViewController _infoViewController;
        BaseContentViewController _songViewController;
		#endregion

		#region constructor
		public ContentViewController(IntPtr handle) : base(handle)
		{
		}

		#endregion

		#region properties
		public Dictionary<int, BaseContentViewController> ViewControllers
		{
			get { return _viewControllerDicitonary; }
			set
			{
				_viewControllerDicitonary = value;
			}
		}

		public UIViewController ActiveViewController
		{
			get { return _activeViewController; }
			set
			{
				RemoveInactiveViewController(_activeViewController);
				_activeViewController = value;
				UpdateActiveViewController();
			}
		}
		#endregion

		#region public methods

		#region override methods

		#region Viewcycle
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			btnOpenMenu.TouchUpInside+= BtnOpenMenu_TouchUpInside;
			imgBurger.Image = UIImage.FromBundle("SharedAssets/Images/General/burger.png");
			AppController.Instance.NavigationController.GoToPageEvent+= GoToPageHandler;
			createContentViewControllers();
		}

	#endregion

		#endregion

		#endregion

		#region private methods
		void BtnOpenMenu_TouchUpInside(object sender, EventArgs e)
		{
			SidebarController.ToggleMenu();
		}


		void GoToPageHandler(ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum page, ScoutsEnGidsen.HO.BL.Controllers.BaseContentController controller)
		{
			BaseContentViewController contentViewController = null;
			switch (page)
			{
                case ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum.INTRO:
                    contentViewController = _introViewController;
					break;
				case ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum.PROGRAM:
                    contentViewController = _programmViewController;
					break;
                case ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum.MAP:
                    contentViewController = _mapViewController;
                    break;
                case ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum.INFO:
                    contentViewController = _infoViewController;
                    break;
                case ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum.YEARSONG:
                    contentViewController = _songViewController;
                    break;
				default:
					break;
			}
            if (contentViewController != null)
                contentViewController.Controller = controller;
			ActiveViewController = contentViewController;
            if (SidebarController != null)
			    SidebarController.CloseMenu();

		}

		void RemoveInactiveViewController(UIViewController inactiveViewController)
		{
			if (IsViewLoaded)
			{
				if (inactiveViewController != null)
				{
					inactiveViewController.WillMoveToParentViewController(null);
					inactiveViewController.View.RemoveFromSuperview();
					inactiveViewController.RemoveFromParentViewController();
				}
			}
		}

		void UpdateActiveViewController()
		{
			if (IsViewLoaded)
			{
				if (ActiveViewController != null)
				{
					AddChildViewController(ActiveViewController);
					ActiveViewController.View.Frame = vwContent.Bounds;
					vwContent.AddSubview(ActiveViewController.View);
					ActiveViewController.DidMoveToParentViewController(this);
				}
			}
		}

		void createContentViewControllers()
		{
            _introViewController = Storyboard.InstantiateViewController("IntroViewController") as BaseContentViewController;
            _programmViewController = Storyboard.InstantiateViewController("ProgramViewController") as BaseContentViewController;
            _mapViewController = Storyboard.InstantiateViewController("MapImageView") as BaseContentViewController;
            _infoViewController = Storyboard.InstantiateViewController("InfoViewController") as BaseContentViewController;
            _songViewController = Storyboard.InstantiateViewController("SongViewController") as BaseContentViewController;

			AppController.Instance.NavigationController.SideMenuButtonClicked(ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum.INTRO);
		}
		#endregion



	}
}
