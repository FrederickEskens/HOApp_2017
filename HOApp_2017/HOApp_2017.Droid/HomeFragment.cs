using System.Text;

using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace HOApp_2017.Droid
{
    public class HomeFragment : Fragment
    {
        ImageView HeaderImage;
        TextView Title;
        TextView Body;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.ContentBase, container, false);

            HeaderImage = view.FindViewById<ImageView>(Resource.Id.header_image);
            Title = view.FindViewById<TextView>(Resource.Id.title);
            Body = view.FindViewById<TextView>(Resource.Id.body);

            HeaderImage.SetImageResource(Resource.Drawable.headers_intro);
            Title.Text = "Herfstontmoeting";

            Body.Text = FillBody();

            return view;
        }

        private string FillBody()
        {
            var sb = new StringBuilder();
            sb.AppendLine(
                "Herfstontmoeting is het startweekend voor alle leiding van Scouts en Gidsen Vlaanderen. Deze app is jouw digitale gids doorheen het weekend.");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Tip: gebruik de knop links bovenaan om het menu te openen.");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Veel plezier!");
            sb.Append(System.Environment.NewLine);
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Welkom op HO!");
            sb.AppendLine("van de verbondscommissaris");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Of ik gegroeid ben binnen scouting? Daar stond ik nog niet bij stil.");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine(
                "Uit verschillende uniformen gegroeid, dat uiteraard. Maar toch vooral voor de fun bij de scouts gebleven. En omdat ik nieuwe dingen leerde kennen. Of ja, later werd dat voor de vrienden. En eigenlijk ook voor de kansen en de vrijheid die we er kregen. En voor de verantwoordelijkheid waar we er stapsgewijs steeds meer van mochten dragen. Voor de experimenteerkansen. Om iets door te geven aan de jongverkenners. Om met de groep op stap te mogen gaan.");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine(
                "Dus gegroeid? Ja, eigenlijk wel. Ferm gegroeid zelfs, van kapoen tot groepsleider. Herfstontmoeting als start van een jaar vol groeikansen? Ik gun het jullie en ik gun het onze leden.");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Ga ervoor! Santé. Op de groei!");
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("Een stevige linker,");
            sb.AppendLine("Christophe Lambrechts, ");
            sb.AppendLine("verbondscommissaris");

            return sb.ToString();
        }
    }
}