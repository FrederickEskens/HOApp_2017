using Android.OS;
using Android.Views;

namespace HOApp_2017.Droid
{
    public class AboutFragment : ContentBaseFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            HeaderImage.SetImageResource(Resource.Drawable.headers_about);
            Title.Text = "Over deze app";

            return view;
        }
    }
}