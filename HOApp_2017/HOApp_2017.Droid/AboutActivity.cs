using Android.App;
using Android.OS;

namespace HOApp_2017.Droid
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : ContentBaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            HeaderImage.SetImageResource(Resource.Drawable.headers_about);
            Title.Text = "Over deze app";
        }
    }
}