using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    public class AboutFragment : BaseContentFragmen
    {
        private ImageView headerImage;
        private TextView title;

        private TextView devTextView;
        private TextView testersTextView;
        private TextView photosTextView;
        private TextView illustrationsTextView;
        private TextView badgeTextView;
        private TextView thanksTextView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.About, container, false);

            headerImage = view.FindViewById<ImageView>(Resource.Id.header_image);
            title = view.FindViewById<TextView>(Resource.Id.about_title);

            devTextView = view.FindViewById<TextView>(Resource.Id.about_dev);
            testersTextView = view.FindViewById<TextView>(Resource.Id.about_testers);
            photosTextView = view.FindViewById<TextView>(Resource.Id.about_photos);
            illustrationsTextView = view.FindViewById<TextView>(Resource.Id.about_illustrations);
            badgeTextView = view.FindViewById<TextView>(Resource.Id.about_badge);
            thanksTextView = view.FindViewById<TextView>(Resource.Id.about_thanks);

            headerImage.SetImageResource(Resource.Drawable.headers_about);
            title.Text = "Over deze app";

            PopulateCredits();

            return view;
        }

        private void PopulateCredits()
        {
            var devResource = Resources.GetStringArray(Resource.Array.about_dev);
            var testersResource = Resources.GetStringArray(Resource.Array.about_testers);
            var photosResource = Resources.GetStringArray(Resource.Array.about_photos);
            var illustrationsResource = Resources.GetStringArray(Resource.Array.about_illustrations);
            var badgeResource = Resources.GetStringArray(Resource.Array.about_badge);
            var thanksResource = Resources.GetStringArray(Resource.Array.about_thanks);

            BuildTextView(devTextView, devResource);
            BuildTextView(testersTextView, testersResource);
            BuildTextView(photosTextView, photosResource);
            BuildTextView(illustrationsTextView, illustrationsResource);
            BuildTextView(badgeTextView, badgeResource);
            BuildTextView(thanksTextView, thanksResource);
        }

        private static void BuildTextView(TextView textView, string[] resource)
        {
            foreach (var item in resource)
            {
                textView.Text += item;
                textView.Text += ", ";
            }

            textView.Text = textView.Text.Substring(0, textView.Text.Length - 2);
        }
    }
}