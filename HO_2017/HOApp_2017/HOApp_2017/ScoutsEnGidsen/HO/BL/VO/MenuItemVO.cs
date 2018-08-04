//
// MenuItemVO.cs
//
// Author:
//       Jeroen Crevits <jeroen@bazookas.be>
//
// Copyright (c) 2017 Bazookas
//
using System;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;

namespace HOApp_2017.ScoutsEnGidsen.HO.BL.VO
{
	public class MenuItemVO
	{
		public MenuItemVO()
		{
		}

		public MenuItemVO(string menuItemText, NavigationController.PagesEnum page)
		{
			MenuItemText = menuItemText;
			Page = page;
		}

		public string MenuItemText
		{
			get;
			set;
		}

		public NavigationController.PagesEnum Page
		{
			get;
			set;
		}
	}
}
