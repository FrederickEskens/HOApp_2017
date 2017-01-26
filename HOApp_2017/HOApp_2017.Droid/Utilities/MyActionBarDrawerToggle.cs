using Android.Support.V4.Widget;
using Android.Support.V7.App;

using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;

namespace HOApp_2017.Droid.Utilities
{
    public class MyActionBarDrawerToggle : SupportActionBarDrawerToggle
    {
        private readonly AppCompatActivity _hostActivity;

        public MyActionBarDrawerToggle(AppCompatActivity host, DrawerLayout drawerLayout)
        : base(host, drawerLayout, Resource.String.app_name, Resource.String.app_name)
        {
            _hostActivity = host;
        }

        public override void OnDrawerOpened(Android.Views.View drawerView)
        {
            var drawerType = (int)drawerView.Tag;

            if (drawerType == 0)
            {
                base.OnDrawerOpened(drawerView);
                _hostActivity.SupportActionBar.SetTitle(Resource.String.app_name);
            }
        }

        public override void OnDrawerClosed(Android.Views.View drawerView)
        {
            var drawerType = (int)drawerView.Tag;

            if (drawerType == 0)
            {
                base.OnDrawerClosed(drawerView);
                _hostActivity.SupportActionBar.SetTitle(Resource.String.app_name);
            }
        }

        public override void OnDrawerSlide(Android.Views.View drawerView, float slideOffset)
        {
            var drawerType = (int)drawerView.Tag;

            if (drawerType == 0)
            {
                base.OnDrawerSlide(drawerView, slideOffset);
            }
        }
    }
}