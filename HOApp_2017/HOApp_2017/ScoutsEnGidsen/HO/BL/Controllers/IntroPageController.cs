//
// IntroPageController.cs
//
// Author:
//       Jeroen Crevits <jeroen@bazookas.be>
//
// Copyright (c) 2017 Bazookas
//
using System;
namespace HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers
{
	public class IntroPageController:BaseContentController
	{
        string _title;
        string _subTitle;
        string _introText;
		public IntroPageController()
		{
		}

		public override string ContentPageName
		{
			get
			{
				return "Intro";
			}
		}

        public string Title
        {
            get{
                if (_title == null)
                    _title = AppController.Instance.GetCopy("Intro_Title");
                return _title;
            }
        }

        public string SubTitle
        {
			get
			{
				if (_subTitle == null)
					_subTitle = AppController.Instance.GetCopy("Intro_SubTitle");
				return _subTitle;
			}
        }

        public string IntroText
        {
			get
			{
				if (_introText == null)
					_introText = AppController.Instance.GetCopy("Intro_IntroText");
				return _introText;
			}
        }
	}
}
