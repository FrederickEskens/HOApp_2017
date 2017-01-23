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
    [Activity(Label = "JaarliedActivity")]
    public class JaarliedActivity : ContentBaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            HeaderImage.SetImageResource(Resource.Drawable.headers_jaarlied);
            Title.Text = "Jaarlied";
        }
    }
}