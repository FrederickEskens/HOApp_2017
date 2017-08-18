using Android.Gms.Maps;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace HOApp_2017.Droid
{
    public class KaartFragment : BaseContentFragmen
    {
        private GoogleMap map;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.ContentBase, container, false);

            

            return view;
        }

       
    }
}