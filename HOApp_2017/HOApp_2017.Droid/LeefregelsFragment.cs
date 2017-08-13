using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;

namespace HOApp_2017.Droid
{
    public class LeefregelsFragment : BaseContentFragmen
    {
        RulesPageController _rulesController{
            get{
                if (ContentController is RulesPageController)
                    return ContentController as RulesPageController;
                else
                    return null;
            }
        }

        TextView title;
        TextView leefregelsIntro;
        TextView leefregelsOutro;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.Leefregels, container, false);
            title = view.FindViewById<TextView>(Resource.Id.leefregels_title);
            leefregelsIntro = view.FindViewById<TextView>(Resource.Id.leefregels_intro);
            leefregelsOutro = view.FindViewById<TextView>(Resource.Id.leefregels_outro);



            return view;
        }

        public override void OnResume()
        {
            base.OnResume();
			title.Text = _rulesController.Title;
			leefregelsIntro.Text =
							   _rulesController.IntroText;
			leefregelsOutro.Text =
							   _rulesController.FooterText;
        }
    }
}