﻿//
// BaseContentViewController.cs
//
// Author:
//       Jeroen Crevits <jeroen@bazookas.be>
//
// Copyright (c) 2017 Bazookas
//
using System;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;

namespace HOApp_2017.iOS.SG.ViewControllers.Base
{
	public class BaseContentViewController:BaseViewController
	{
		public BaseContentViewController(IntPtr handle) : base(handle)
		{
		}
        public BaseContentController Controller { get; set; }
        public virtual void SetData(){
            
        }

	}
}
