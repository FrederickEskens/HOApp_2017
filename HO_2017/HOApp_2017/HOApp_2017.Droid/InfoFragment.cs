using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android;
using Android.Content.PM;

namespace HOApp_2017.Droid
{
    public class InfoFragment : BaseContentFragmen, View.IOnClickListener
    {
        TextView emergencyCall;

        public void OnClick(View v)
        {
            if (v == emergencyCall)
            {
                String number = "tel:+32474261401";
                Intent callIntent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse(number));
                if (Activity.CheckSelfPermission(Manifest.Permission.CallPhone) != Permission.Granted)
                {
                    Activity.RequestPermissions(new String[] { Manifest.Permission.CallPhone }, 1);
                }
                else
                {
                    Activity.StartActivity(callIntent);
                }
                
                
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.About, container, false);
            emergencyCall = view.FindViewById<TextView>(Resource.Id.emergencyButton);
            emergencyCall.SetOnClickListener(this);
           
            return view;
        }

        public void CallPermissionGranted()
        {
            String number = "tel:+32474261401";
            Intent callIntent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse(number));
            Activity.StartActivity(callIntent);
        }

        
    }
}