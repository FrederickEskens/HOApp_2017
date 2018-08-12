package scoutsengidsenvlaanderen.be.hogids;

import android.database.Cursor;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.MenuItem;
import android.widget.TextView;
import android.database.sqlite.SQLiteDatabase;
import android.database.SQLException;

import com.mapbox.mapboxsdk.Mapbox;
import com.mapbox.mapboxsdk.camera.CameraPosition;
import com.mapbox.mapboxsdk.constants.Style;
import com.mapbox.mapboxsdk.geometry.LatLng;
import com.mapbox.mapboxsdk.geometry.LatLngBounds;
import com.mapbox.mapboxsdk.maps.MapView;
import com.mapbox.mapboxsdk.maps.MapboxMap;
import com.mapbox.mapboxsdk.maps.MapboxMapOptions;
import com.mapbox.mapboxsdk.maps.OnMapReadyCallback;
import com.mapbox.mapboxsdk.maps.SupportMapFragment;
import com.mapbox.mapboxsdk.plugins.locationlayer.LocationLayerPlugin;
import com.mapbox.mapboxsdk.plugins.locationlayer.modes.CameraMode;

import java.io.IOException;

import scoutsengidsenvlaanderen.be.hogids.fragments.IntroFragment;
import scoutsengidsenvlaanderen.be.hogids.fragments.MapFragment;
import scoutsengidsenvlaanderen.be.hogids.fragments.MoreFragment;
import scoutsengidsenvlaanderen.be.hogids.fragments.ProgramFragment;
import scoutsengidsenvlaanderen.be.hogids.fragments.ThemeFragment;


public class MainActivity extends AppCompatActivity {
    private DatabaseHelper mDBHelper;
    private SQLiteDatabase mDb;
    private TextView mTextMessage;

    private ProgramFragment programFragment = ProgramFragment.newInstance("","");
    private SupportMapFragment mapFragment;
    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {

        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            switch (item.getItemId()) {
                case R.id.navigation_home:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM1"));
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragmentHolder, IntroFragment.newInstance()).commit();
                    return true;
                case R.id.navigation_program:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM2"));
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragmentHolder, programFragment).commit();
                    return true;
                case R.id.navigation_map:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM3"));
                    MapboxMapOptions options = new MapboxMapOptions();
                    options.styleUrl("mapbox://styles/crejer/cjkgp87eb1wvv2rpg9vdunmso");
                    options.camera(new CameraPosition.Builder().zoom(14).build());
                    mapFragment = SupportMapFragment.newInstance(options);
                    mapFragment.getMapAsync(new OnMapReadyCallback() {
                        @Override
                        public void onMapReady(MapboxMap mapboxMap) {
                            // Set bounds to Australia
                            mapboxMap.setLatLngBoundsForCameraTarget(HO_BOUNDS);
                            mapboxMap.setMinZoomPreference(12);
                            mapboxMap.setMaxZoomPreference(16.5);

                            LocationLayerPlugin locationLayerPlugin = new LocationLayerPlugin((MapView)mapFragment.getView(), mapboxMap);

                            // Set the plugin's camera mode
                            locationLayerPlugin.setCameraMode(CameraMode.TRACKING);
                            getLifecycle().addObserver(locationLayerPlugin);
                        }
                    });
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragmentHolder, mapFragment).commit();
                    return true;
                case R.id.navigation_theme:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM4"));
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragmentHolder, ThemeFragment.newInstance()).commit();
                    return true;
                case R.id.navigation_practical:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM5"));
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragmentHolder, MoreFragment.newInstance()).commit();
                    return true;
            }
            return false;
        }
    };

    private static final LatLngBounds HO_BOUNDS = new LatLngBounds.Builder()
            .include(new LatLng(51.223, 4.894))
            .include(new LatLng(51.262, 4.986))
            .build();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Mapbox.getInstance(this, getString(R.string.mapBox_accestoken));
        mTextMessage = (TextView) findViewById(R.id.message);
        BottomNavigationView navigation = (BottomNavigationView) findViewById(R.id.navigation);
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);



        mDBHelper = new DatabaseHelper(this);

        try {
            mDBHelper.updateDataBase();
        } catch (IOException mIOException) {
            throw new Error("UnableToUpdateDatabase");
        }

        try {
            mDb = mDBHelper.getWritableDatabase();
            LocalStorage.getInstance().setmDb(mDb);
        } catch (SQLException mSQLException) {
            throw mSQLException;
        }

        for(int i = 1; i < 6; i++) {
            MenuItem item = navigation.getMenu().getItem(i - 1);
            item.setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM" + i));
        }


        navigation.setSelectedItemId(R.id.navigation_home);

    }

}
