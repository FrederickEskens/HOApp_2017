using System.Text;

using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using Com.Bumptech.Glide;

namespace HOApp_2017.Droid
{
    public class HomeFragment : BaseContentFragmen
    {
        private ImageView headerImage;
        private TextView title;
        private TextView body;
        private TextView subtitle;

         IntroPageController IntroController
        {
            get{
                if (ContentController is IntroPageController)
                    return ContentController as IntroPageController;
                else
                    return null;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.ContentBase, container, false);

            headerImage = view.FindViewById<ImageView>(Resource.Id.header_image);
            title = view.FindViewById<TextView>(Resource.Id.title);
            body = view.FindViewById<TextView>(Resource.Id.body);
            subtitle = view.FindViewById<TextView>(Resource.Id.subTitle);



            return view;
        }
        public override void OnResume()
        {
            base.OnResume();
            Glide.With(Activity).Load(Resource.Drawable.anton).Into(headerImage);
			//headerImage.SetImageResource(Resource.Drawable.anton);
			if (IntroController != null)
				title.Text = IntroController.Title;
			if (IntroController != null)
				body.Text = IntroController.IntroText;
            if (IntroController != null)
                subtitle.Text = IntroController.SubTitle;
        }
    }
}