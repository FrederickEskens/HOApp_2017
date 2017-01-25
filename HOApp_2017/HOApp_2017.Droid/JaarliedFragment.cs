using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Resource = HOApp_2017.Droid.Resource;

namespace NavigationDrawer
{
    public class JaarliedFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.ContentBase, container, false);

            var HeaderImage = view.FindViewById<ImageView>(Resource.Id.header_image);
            var Title = view.FindViewById<TextView>(Resource.Id.title);
            var Body = view.FindViewById<TextView>(Resource.Id.body);

            HeaderImage.SetImageResource(Resource.Drawable.headers_jaarlied);
            Title.Text = "Jaarlied";

            return view;
        }
    }
}

