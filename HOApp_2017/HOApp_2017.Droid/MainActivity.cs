using System.Text;

using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HOApp_2017.Droid
{
	[Activity (Label = "HO 2017", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            RequestWindowFeature(WindowFeatures.NoTitle);

            SetContentView (Resource.Layout.Main);

		    var body = FindViewById<TextView>(Resource.Id.body);

            var sb = new StringBuilder();
		    sb.AppendLine(
		        "Herfstontmoeting is het startweekend voor alle leiding van Scouts en Gidsen Vlaanderen. Deze app is jouw digitale gids doorheen het weekend.");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Tip: gebruik de knop links bovenaan om het menu te openen.");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Veel plezier!");

		    body.Text = sb.ToString();
		}
	}
}