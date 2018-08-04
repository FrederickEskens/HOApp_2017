using System;
namespace HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers
{
    public class InfoPageController:BaseContentController
    {
        public InfoPageController()
        {
        }

        public override string ContentPageName => "Info";

        public void ShowFirstAidLocation(){
            AppController.Instance.NavigationController.ShowFirstAidOnMap();
        }
    }
}
