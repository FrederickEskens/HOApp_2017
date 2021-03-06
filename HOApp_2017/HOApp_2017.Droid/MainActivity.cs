using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;

using HOApp_2017.Droid.Utilities;
using HOApp_2017.ScoutsEnGidsen.HO.BL.Controllers;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Widget;
using Com.Bumptech.Glide;
using Android.Content.PM;
using Android.Runtime;

namespace HOApp_2017.Droid
{
    [Activity(Label = "HO 2017", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity,View.IOnClickListener
    {
        private DrawerLayout drawerLayout;
        private MyActionBarDrawerToggle drawerToggle;
        private ImageView logoimageView;
        private TextView headerTextView;

        HomeFragment _homeFragment;
        KaartFragment _mapFragment;
        InstellingenFragment _settingsFragment;
        JaarliedFragment _yearSongFragment;
        LeefregelsFragment _liveRulesFragment;
        ProgramFragment _programFragment;
        InfoFragment _infoFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            logoimageView = FindViewById<ImageView>(Resource.Id.menuLogo);
            headerTextView = FindViewById<TextView>(Resource.Id.HeaderText);
            // Init toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            // Attach item selected handler to navigation view
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            AppController.Instance.NavigationController.GoToPageEvent+= NavigationController_GoToPageEvent;;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            drawerToggle = new MyActionBarDrawerToggle(this, drawerLayout);
            drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            createContentFragments();
            // Load default home screen
            if (savedInstanceState == null)
            AppController.Instance.NavigationController.SideMenuButtonClicked(NavigationController.PagesEnum.INTRO);

            Glide.With(this).Load(Resource.Drawable.hologo).Into(logoimageView);

            headerTextView.SetOnClickListener(this);
        }

        private void createContentFragments()
        {
            _homeFragment = new HomeFragment();
            _mapFragment = new KaartFragment();
            _liveRulesFragment = new LeefregelsFragment();
            _settingsFragment = new InstellingenFragment();
            _yearSongFragment = new JaarliedFragment();
            _programFragment = new ProgramFragment();
            _infoFragment = new InfoFragment();
        }

        private void LoadFragment(Fragment fragment)
        {
            //TODO: optimize
            //TODO: configure AddToBackStack
            var ft = SupportFragmentManager.BeginTransaction();
            ft.AddToBackStack(null);
            ft.Replace(Resource.Id.FrameLayout, fragment);
            ft.Commit();
        }

        protected override void OnResume()
        {
            SupportActionBar.SetTitle(Resource.String.app_name);
            base.OnResume();
        }

        // Define action for navigation menu selection
        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var selectedPage = NavigationController.PagesEnum.INTRO;
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_programma):
                    selectedPage = NavigationController.PagesEnum.PROGRAM;
                    break;
                case (Resource.Id.nav_kaart):
                    selectedPage = NavigationController.PagesEnum.MAP;
                    break;
                case (Resource.Id.nav_praktisch):
                    selectedPage = NavigationController.PagesEnum.INFO;
                    break;
                case (Resource.Id.nav_leefregels):
                    selectedPage = NavigationController.PagesEnum.LIVERULES;
                    break;
                case (Resource.Id.nav_jaarlied):
                    selectedPage = NavigationController.PagesEnum.YEARSONG;
                    break;
                //case (Resource.Id.nav_instellingen):
                //    selectedPage = NavigationController.PagesEnum.SETTINGS;
                //    break;
                //case (Resource.Id.nav_about):
                //    selectedPage = NavigationController.PagesEnum.ABOUT;
                //    break;
            }
            AppController.Instance.NavigationController.SideMenuButtonClicked(selectedPage);
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

        void NavigationController_GoToPageEvent(ScoutsEnGidsen.HO.BL.Controllers.NavigationController.PagesEnum page, ScoutsEnGidsen.HO.BL.Controllers.BaseContentController controller)
        {
            BaseContentFragmen contentFragment;
            switch (page)
            {
                default:
                    contentFragment = _homeFragment;
                    break;
                case NavigationController.PagesEnum.INTRO:
                    contentFragment = _homeFragment;
                    break;
                case NavigationController.PagesEnum.MAP:
                    contentFragment = _mapFragment;
                    break;
                case NavigationController.PagesEnum.PROGRAM:
                    contentFragment = _programFragment;
                    break;
                case NavigationController.PagesEnum.INFO:
                    contentFragment = _infoFragment;
                    break;
                case NavigationController.PagesEnum.LIVERULES:
                    contentFragment = _liveRulesFragment;
                    break;
                case NavigationController.PagesEnum.YEARSONG:
                    contentFragment = _yearSongFragment;
                    break;
                case NavigationController.PagesEnum.SETTINGS:
                    contentFragment = _settingsFragment;
                    break;
            }
            if (controller != null){
                contentFragment.ContentController = controller;
            }
            LoadFragment(contentFragment);
        }

        // To avoid direct app exit on backpressed and to show fragment from stack
        public override void OnBackPressed()
        {
            //TODO: prevent white screen on end of stack
            if (FragmentManager.BackStackEntryCount != 0)
            {
                FragmentManager.PopBackStack();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public void OnClick(View v)
        {
            if (v == headerTextView)
            {
                AppController.Instance.NavigationController.SideMenuButtonClicked(NavigationController.PagesEnum.INTRO);
                drawerLayout.CloseDrawers();
            }
                
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            switch (requestCode)
            {
                case 1:
                    if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                    {
                        if (_infoFragment != null)
                            _infoFragment.CallPermissionGranted();
                    }
                    else
                    {

                    }
                    return;
                    break;
            }
        }
    }
}