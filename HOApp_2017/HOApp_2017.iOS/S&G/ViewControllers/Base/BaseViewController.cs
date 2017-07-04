﻿//
// BaseViewController.cs
//
// Author:
//       Jeroen Crevits <jeroen@bazookas.be>
//
// Copyright (c) 2017 Bazookas
//
using System;
using UIKit;

namespace HOApp_2017.iOS.SG.ViewControllers.Base
{
	public class BaseViewController:UIViewController
	{

		public BaseViewController(IntPtr handle) : base(handle)
		{
		}

		protected SidebarNavigation.SidebarController SidebarController
		{
			get
			{
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.SidebarController;
			}
		}

		// provide access to the storyboard to all inheriting controllers
		public override UIStoryboard Storyboard
		{
			get
			{
				return (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.Storyboard;
			}
		}

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.LightContent;
        }

	}
}
