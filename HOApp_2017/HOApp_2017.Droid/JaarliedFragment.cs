using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    public class JaarliedFragment : Fragment
    {
        private ImageView headerImage;
        private TextView title;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.ContentBase, container, false);

            headerImage = view.FindViewById<ImageView>(Resource.Id.header_image);
            title = view.FindViewById<TextView>(Resource.Id.title);

            headerImage.SetImageResource(Resource.Drawable.headers_jaarlied);
            title.Text = "Jaarlied";

            return view;
        }
    }
}