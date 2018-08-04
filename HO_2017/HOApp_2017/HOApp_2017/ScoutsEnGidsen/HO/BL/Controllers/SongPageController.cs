using System;
namespace HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers
{
    public class SongPageController:BaseContentController
    {
        public SongPageController()
        {
        }
		string _title;
		string _subTitle;
		string _introText;

		public override string ContentPageName
		{
			get
			{
				return "Intro";
			}
		}

		public string Title
		{
			get
			{
				if (_title == null)
					_title = AppController.Instance.GetCopy("Song_Title");
				return _title;
			}
		}

		public string SubTitle
		{
			get
			{
				if (_subTitle == null)
					_subTitle = AppController.Instance.GetCopy("Song_Subtitle");
				return _subTitle;
			}
		}

		public string SongText
		{
			get
			{
				if (_introText == null)
					_introText = AppController.Instance.GetCopy("Song_Text");
				return _introText;
			}
		}
    }
}
