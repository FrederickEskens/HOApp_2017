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
	}
}
