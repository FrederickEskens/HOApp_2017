using System;
namespace HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers
{
    public class RulesPageController:BaseContentController
    {
		string _title;
        string _footerText;
		string _introText;

        public RulesPageController()
        {
        }

        public override string ContentPageName => "Rules";

		public string Title
		{
			get
			{
				if (_title == null)
					_title = AppController.Instance.GetCopy("Rules_Title");
				return _title;
			}
		}

		public string IntroText
		{
			get
			{
                if (_introText == null)
					_introText = AppController.Instance.GetCopy("Rules_IntroText");
				return _introText;
			}
		}

		public string FooterText
		{
			get
			{
				if (_footerText == null)
					_footerText = AppController.Instance.GetCopy("Rules_FooterText");
				return _footerText;
			}
		}
    }
}
