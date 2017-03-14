﻿using System.Collections.Generic;
using HOApp_2017.ScoutsEnGidsen.HO.BL.VO;

namespace HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers {
	public class NavigationController {
		#region delegates
		public delegate void GoToPageDelegate(PagesEnum page, BaseContentController controller);
		#endregion

		#region events
		public event GoToPageDelegate GoToPageEvent;
		#endregion
		#region variables

		#endregion

		#region constructor

		#endregion

		#region properties
		public IEnumerable<MenuItemVO> MenuItems
		{
			get { 
				var menuItems = new List<MenuItemVO>();
				var programItem = new MenuItemVO("Programma",PagesEnum.PROGRAM);
				var mapItem = new MenuItemVO("Kaart", PagesEnum.MAP);
				var infoItem = new MenuItemVO("Praktische info", PagesEnum.INFO);
				var rules = new MenuItemVO("Leefregels", PagesEnum.LIVERULES);
				var song = new MenuItemVO("Jaarlied", PagesEnum.YEARSONG);
				var settings = new MenuItemVO("Instellingen", PagesEnum.SETTINGS);
				var about = new MenuItemVO("Over deze app", PagesEnum.ABOUT);
				menuItems.Add(programItem);
				menuItems.Add(mapItem);
				menuItems.Add(infoItem);
				menuItems.Add(rules);
				menuItems.Add(song);
				menuItems.Add(settings);
				menuItems.Add(about);
				return menuItems;
			}
		}
		#endregion

		#region public methods
		public void SideMenuButtonClicked(PagesEnum page)
		{
			BaseContentController controller;
			switch (page)
			{
				case PagesEnum.INTRO:
					controller = new IntroPageController();
					break;
				default:
					controller = null;
					break;
			}
			if (GoToPageEvent != null)
				GoToPageEvent(page, controller);
		}
		#region override methods

		#region Viewcycle

		#endregion

		#endregion

		#endregion

		#region private methods

		#endregion


		public enum PagesEnum {
			INTRO,
			PROGRAM,
			MAP,
			INFO,
			LIVERULES,
			YEARSONG,
			SETTINGS,
			ABOUT
		}
	}
}