using System;
using Android.Gms.Maps;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Request.Target;
using System.Threading.Tasks;

namespace HOApp_2017.Droid
{
    public class KaartFragment : BaseContentFragmen
    {
        private ImageView map;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(HOApp_2017.Droid.Resource.Layout.MapLayout, container, false);
            
         
           
            return view;
        }
        
    }

    
}