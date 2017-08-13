using Android.Gms.Maps;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace HOApp_2017.Droid
{
    public class KaartFragment : BaseContentFragmen, IOnMapReadyCallback
    {
        private GoogleMap map;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.ContentBase, container, false);

            var mapFragment = new SupportKaartFragment();
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.map, mapFragment).Commit();
            mapFragment.GetMapAsync(this);

            return view;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
        }
    }
}