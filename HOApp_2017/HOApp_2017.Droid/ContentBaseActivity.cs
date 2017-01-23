using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    [Activity(Label = "ContentBaseActivity")]
    public abstract class ContentBaseActivity : Activity
    {
        public ImageView HeaderImage;
        public TextView Title;
        public TextView Body;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.ContentBase);

            HeaderImage = FindViewById<ImageView>(Resource.Id.header_image);
            Title = FindViewById<TextView>(Resource.Id.title);
            Body = FindViewById<TextView>(Resource.Id.body);
        }
    }
}