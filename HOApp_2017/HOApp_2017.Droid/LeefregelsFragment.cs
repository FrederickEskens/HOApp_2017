using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    public class LeefregelsFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.Leefregels, container, false);
            var title = view.FindViewById<TextView>(Resource.Id.leefregels_title);
            var leefregelsIntro = view.FindViewById<TextView>(Resource.Id.leefregels_intro);
            var leefregelsOutro = view.FindViewById<TextView>(Resource.Id.leefregels_outro);

            title.Text = "Leefregels";
            leefregelsIntro.Text =
                "We rekenen erop dat je de wijsheid hebt om volgende zeven vuistregels op te volgen. Bedankt!";
            leefregelsOutro.Text =
                "Door je in te schrijven voor herfstontmoeting, ga je akkoord met volgende leefregels. Overtreed je de leefregels? Dan zal er een sanctie en natraject volgen.";

            return view;
        }
    }
}