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