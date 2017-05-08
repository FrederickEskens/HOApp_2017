using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    public class InstellingenFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.Instellingen, container, false);
            var title = view.FindViewById<TextView>(Resource.Id.instellingen_title);

            title.Text = "Instellingen";
            
            return view;
        }
    }
}