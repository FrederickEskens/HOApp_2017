using Android.App;
using Android.OS;

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