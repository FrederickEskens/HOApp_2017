using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using Com.Bumptech.Glide;

namespace HOApp_2017.Droid
{
    public class JaarliedFragment : BaseContentFragmen
    {
        private ImageView headerImage;
        private TextView title;
        private TextView body;
        private TextView subTitle;

        SongPageController _songController{
            get{
                if (ContentController is SongPageController)
                    return ContentController as SongPageController;
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
            subTitle = view.FindViewById<TextView>(Resource.Id.subTitle);
            headerImage.SetScaleType(ImageView.ScaleType.CenterInside);
            Glide.With(Activity).Load(Resource.Drawable.jaarthema).Into(headerImage);
            
            headerImage.SetBackgroundColor(new Android.Graphics.Color(ContextCompat.GetColor(Activity, Resource.Color.primary_red)));

            return view;
        }

        public override void OnResume()
        {
            base.OnResume();
            if (_songController != null)
            {
                title.Text = _songController.Title;
                body.Text = _songController.SongText;
                subTitle.Text = _songController.SubTitle;
            }
           
        }
    }
}