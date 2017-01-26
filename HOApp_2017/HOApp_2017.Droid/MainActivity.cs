using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using HOApp_2017.Droid.Utilities;

namespace HOApp_2017.Droid
{
    [Activity(Label = "H0 2017", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        MyActionBarDrawerToggle drawerToggle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            // Init toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            // Attach item selected handler to navigation view
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            drawerToggle = new MyActionBarDrawerToggle(this, drawerLayout, Resource.String.app_name, Resource.String.app_name);
            drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            // Load default home screen
            LoadFragment(new HomeFragment());
        }

        private void LoadFragment(Fragment fragment)
        {
            var ft = FragmentManager.BeginTransaction();
            ft.AddToBackStack(null);
            ft.Add(Resource.Id.FrameLayout, fragment);
            ft.Commit();
        }

        protected override void OnResume()
        {
            SupportActionBar.SetTitle(Resource.String.app_name);
            base.OnResume();
        }

        // Define action for navigation menu selection
        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_programma):
                    LoadFragment(new HomeFragment());
                    break;
                case (Resource.Id.nav_kaart):
                    //LoadFragment(new KaartFragment());
                    break;
                case (Resource.Id.nav_praktisch):
                    //LoadFragment(new PraktischFragment());
                    break;
                case (Resource.Id.nav_leefregels):
                    //LoadFragment(new LeefregelsFragment());
                    break;
                case (Resource.Id.nav_jaarlied):
                    LoadFragment(new JaarliedFragment());
                    break;
                case (Resource.Id.nav_instellingen):
                    //LoadFragment(new InstellingenFragment());
                    break;
                case (Resource.Id.nav_about):
                    LoadFragment(new AboutFragment());
                    break;
            }
            
            drawerLayout.CloseDrawers();
        }

        // Define action for toolbar icon press
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerToggle.OnOptionsItemSelected(item);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        // To avoid direct app exit on backpressed and to show fragment from stack
        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount != 0)
            {
                FragmentManager.PopBackStack();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}