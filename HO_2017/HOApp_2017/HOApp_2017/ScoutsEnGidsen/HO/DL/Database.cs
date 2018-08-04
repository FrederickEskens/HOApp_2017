using System;
using System.Collections.Generic;
using System.IO;

#if __ANDROID__
using Android.App;
#endif

#if __IOS__
using Foundation;
using HOApp_2017.ScoutsEnGidsen.HO.DAL.DO;
#endif

using SQLite;

namespace HOApp_2017.ScoutsEnGidsen.HO.DL {
    public class Database {
		SQLiteConnection database;

		#if __ANDROID__
		string originalDBLocation = "HO.sqlite";
        #elif __IOS__
		string originalDBLocation = "SharedAssets/HO.sqlite";
        #endif

        const int DATABASE_VERSION = 2;
		string currentDBName = "HO" + DATABASE_VERSION + ".sqlite";
        string oldDBName = "HO" + (DATABASE_VERSION - 1) + ".sqlite";

        //path of current version of database
        string DatabasePath { 
			get { 
				var sqliteFilename = currentDBName;

                #if __IOS__
				int SystemVersion = Convert.ToInt16(UIKit.UIDevice.CurrentDevice.SystemVersion.Split('.')[0]);
				string documentsPath = SystemVersion >= 8 ? NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path : Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				var path = Path.Combine(documentsPath, sqliteFilename);

                #elif __ANDROID__
                string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				var path = Path.Combine(documentsPath, sqliteFilename);
                #endif

                return path;
			}
		}

        //path of previous version of database
        string OldDatabasePath {
            get {
                var sqliteFilename = oldDBName;

                #if __IOS__
				int SystemVersion = Convert.ToInt16(UIKit.UIDevice.CurrentDevice.SystemVersion.Split('.')[0]);
				string documentsPath = SystemVersion >= 8 ? NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path : Environment.GetFolderPath (Environment.SpecialFolder.Personal);
				var path = Path.Combine(documentsPath, sqliteFilename);

                #elif __ANDROID__
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, sqliteFilename);
                #endif

                return path;
            }
        }

        //reads the write stream.
        void ReadWriteStream(Stream readStream, Stream writeStream) {
			int Length = 256;
			var buffer = new byte[Length];
			int bytesRead = readStream.Read(buffer, 0, Length);
			// write the required bytes
			while (bytesRead > 0) {
				writeStream.Write(buffer, 0, bytesRead);
				bytesRead = readStream.Read(buffer, 0, Length);
			}
			readStream.Close();
			writeStream.Close();
		}

		//initializes a new instance of the database
		//if the database doesn't exist, it will create the database
		public Database() {
			var dbPath = DatabasePath;

			if (!File.Exists (dbPath))
                CreateDatabase(dbPath);

            database = new SQLiteConnection(dbPath);			
		}

        void CreateDatabase(string dbPath) {
            #if __ANDROID__
            var s = Application.Context.Assets.Open(originalDBLocation);
            var writeStream = new FileStream(dbPath, FileMode.OpenOrCreate, FileAccess.Write);
            ReadWriteStream(s, writeStream);
            writeStream.Close();

            #elif __IOS__
			var appDir = NSBundle.MainBundle.ResourcePath;
			var originalLocation = Path.Combine (appDir, originalDBLocation);
			File.Copy (originalLocation, dbPath);
            #endif

            //copies profiles and selected eigenschappen from the old database to the new one
            if (File.Exists(OldDatabasePath)) {
                SQLiteConnection oldDb = new SQLiteConnection(OldDatabasePath);
                SQLiteConnection newDB = new SQLiteConnection(dbPath);

				//TODO Keep several old db values in new DB
                
                oldDb.Dispose();
                newDB.Dispose();
                File.Delete(OldDatabasePath);
            }
        }

        
        /* ------------------------------ Get Copy ------------------------------ */

		//extract eigenschappen from DB and put them in a list
		public List<CopyDO> GetAllCopy(string lang = "NL")
		{
			lock (database)
			{
				var cmd = new SQLiteCommand(database);
				cmd.CommandText = "select * from tblCopy";
				var copyItems = cmd.ExecuteQuery<CopyDO>();
				return copyItems;
			}
		}

        public List<LocationDO> GetAllLocations(){
			lock (database)
			{
				var cmd = new SQLiteCommand(database);
				cmd.CommandText = "select * from tblLocations";
				var copyItems = cmd.ExecuteQuery<LocationDO>();
				return copyItems;
			}
        }

		public List<ProgramItemDO> GetAllProgramItems()
		{
			lock (database)
			{
				var cmd = new SQLiteCommand(database);
				cmd.CommandText = "select * from tblProgram";
                var copyItems = cmd.ExecuteQuery<ProgramItemDO>();
				return copyItems;
			}
		}

	}
}