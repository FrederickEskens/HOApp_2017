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
import java.io.IOException;

import scoutsengidsenvlaanderen.be.hogids.fragments.IntroFragment;
import scoutsengidsenvlaanderen.be.hogids.fragments.ProgramFragment;


public class MainActivity extends AppCompatActivity {
    private DatabaseHelper mDBHelper;
    private SQLiteDatabase mDb;
    private TextView mTextMessage;

    private IntroFragment introFragment = IntroFragment.newInstance();
    private ProgramFragment programFragment = ProgramFragment.newInstance("","");

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {

        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            switch (item.getItemId()) {
                case R.id.navigation_home:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM1"));
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragmentHolder, introFragment).commit();
                    return true;
                case R.id.navigation_program:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM2"));
                    getSupportFragmentManager().beginTransaction().replace(R.id.fragmentHolder, programFragment).commit();
                    return true;
                case R.id.navigation_map:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM3"));
                    return true;
                case R.id.navigation_theme:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM4"));
                    return true;
                case R.id.navigation_practical:
                    setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM5"));
                    return true;
            }
            return false;
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mTextMessage = (TextView) findViewById(R.id.message);
        BottomNavigationView navigation = (BottomNavigationView) findViewById(R.id.navigation);
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);

        for(int i = 1; i < 6; i++) {
            MenuItem item = navigation.getMenu().getItem(i - 1);
            item.setTitle(LocalStorage.getInstance().getCopy("TABBAR_ITEM" + i));
        }

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

        navigation.setSelectedItemId(R.id.navigation_home);

    }

}
