using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    public class AboutFragment : Fragment
    {
        ImageView HeaderImage;
        TextView Title;
        TextView Body;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.About, container, false);

            HeaderImage = view.FindViewById<ImageView>(Resource.Id.header_image);
            Title = view.FindViewById<TextView>(Resource.Id.about_title);
            Body = view.FindViewById<TextView>(Resource.Id.body);

            HeaderImage.SetImageResource(Resource.Drawable.headers_about);
            Title.Text = "Over deze app";

            return view;
        }
    }
}