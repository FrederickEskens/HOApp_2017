package scoutsengidsenvlaanderen.be.hogids;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.ArrayMap;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import scoutsengidsenvlaanderen.be.hogids.fragments.dummy.DummyContent;

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

    public ArrayList<DummyContent.DummyItem> getProgramItems(int forDay){
        ArrayList<DummyContent.DummyItem> programItems = new ArrayList<>();
        if (mDb != null) {
            Cursor cursor = mDb.rawQuery("SELECT * FROM tblProgram WHERE ParentID=?", new String[]{String.valueOf(forDay)});
            cursor.moveToFirst();
            while(!cursor.isAfterLast()){
                String startHour = (cursor.getString(3) == null || cursor.getString(3).isEmpty()) ? "...":cursor.getString(3);
                String endHour = (cursor.getString(4) == null || cursor.getString(3).isEmpty()) ? "...":cursor.getString(4);
                programItems.add(new DummyContent.DummyItem((startHour + " - " + endHour),cursor.getString(2),getLocationName(cursor.getInt(5))));
                cursor.moveToNext();
            }
            cursor.close();
        }

        return  programItems;

    }

    public String getLocationName(int forID){
        String name = "";
        if (mDb != null) {
            Cursor cursor = mDb.rawQuery("SELECT * FROM tblLocations WHERE ID=?", new String[]{String.valueOf(forID)});
            cursor.moveToFirst();
            while(!cursor.isAfterLast()){
                name = cursor.getString(1);
                cursor.moveToNext();
            }
            cursor.close();
        }
        return (name == null || name.isEmpty()) ? "" : name;
    }



}
