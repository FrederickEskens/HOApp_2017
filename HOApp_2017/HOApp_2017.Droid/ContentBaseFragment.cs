using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    public abstract class ContentBaseFragment : Fragment
    {
        protected ImageView HeaderImage;
        protected TextView Title;
        protected TextView Body;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.ContentBase, container, false);

            HeaderImage = view.FindViewById<ImageView>(Resource.Id.header_image);
            Title = view.FindViewById<TextView>(Resource.Id.title);
            Body = view.FindViewById<TextView>(Resource.Id.body);

            return view;
        }
    }
}