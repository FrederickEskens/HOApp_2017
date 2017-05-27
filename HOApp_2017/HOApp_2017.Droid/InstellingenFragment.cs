using System;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
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
            var spinner = view.FindViewById<Spinner>(Resource.Id.gouw_spinner);

            var adapter = ArrayAdapter.CreateFromResource(Activity.ApplicationContext, Resource.Array.gouw_array,
               Resource.Layout.spinner_item);

            adapter.SetDropDownViewResource(Resource.Layout.simple_spinner_dropdown_item);

            spinner.Adapter = adapter;

            title.Text = "Instellingen";
            
            return view;
        }
    }

    public class CustomOnItemSelectedListener : AdapterView.IOnItemSelectedListener
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IntPtr Handle { get; }
        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            ((TextView) parent.GetChildAt(0)).SetTextColor(Color.Black);
        }

        public void OnNothingSelected(AdapterView parent)
        {
            throw new NotImplementedException();
        }
    }
}