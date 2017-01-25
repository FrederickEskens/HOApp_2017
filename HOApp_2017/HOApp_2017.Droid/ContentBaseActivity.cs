using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using NavigationDrawer;

namespace HOApp_2017.Droid
{
    [Activity(Label = "H0 2017", MainLauncher = true)]
    public class ContentBaseActivity : AppCompatActivity
    {
        public ImageView HeaderImage;
        public TextView Title;
        public TextView Body;

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

            //load default home screen
            LoadFragment(new HomeFragment());

            HeaderImage = FindViewById<ImageView>(Resource.Id.header_image);
            Title = FindViewById<TextView>(Resource.Id.title);
            Body = FindViewById<TextView>(Resource.Id.body);
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

        //define action for navigation menu selection
        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_programma):
                    LoadFragment(new HomeFragment());
                    break;
                case (Resource.Id.nav_kaart):
                    Toast.MakeText(this, "Message selected!", ToastLength.Short).Show();
                    break;
                case (Resource.Id.nav_praktisch):
                    // React on 'Friends' selection
                    break;
                case (Resource.Id.nav_leefregels):
                    // React on 'Friends' selection
                    break;
                case (Resource.Id.nav_jaarlied):
                    LoadFragment(new JaarliedFragment());
                    break;
                case (Resource.Id.nav_instellingen):
                    // React on 'Friends' selection
                    break;
                case (Resource.Id.nav_about):
                    // React on 'Friends' selection
                    break;
            }
            // Close drawer
            drawerLayout.CloseDrawers();
        }

        //define action for toolbar icon press
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
        //to avoid direct app exit on backpreesed and to show fragment from stack
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