package scoutsengidsenvlaanderen.be.hogids;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.ArrayMap;
import android.util.Log;

import java.util.Map;

/**
 * Created by jeroencrevits on 05/08/2018.
 */

public class LocalStorage {
    private static final LocalStorage ourInstance = new LocalStorage();

    public static LocalStorage getInstance() {
        return ourInstance;
    }

    private SQLiteDatabase mDb;
    private Map<String, String> translations;

    private LocalStorage() {

    }

    public void setmDb(SQLiteDatabase db){
        mDb = db;
    }

    public String getCopy(String key){
        if (mDb != null) {
            if (translations == null) {
                translations = new ArrayMap<>();
                Cursor cursor = mDb.rawQuery("SELECT * FROM tblCopy", null);
                cursor.moveToFirst();
                while (!cursor.isAfterLast()) {
                    translations.put(cursor.getString(0), cursor.getString(1));
                    cursor.moveToNext();
                }
                cursor.close();
            }

            String value = translations.get(key);
            if (value != null) {
                return value;
            } else {
                Log.e("COPY NOT FOUND", key);
                return key;
            }
        }else {
            Log.e("Database not ready!", key);
            return key;
        }
    }



}
