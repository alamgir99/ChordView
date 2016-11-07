using System;
using Xamarin.Forms;
using System.IO;
using ChordView.iOS;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Foundation;
using ChordView;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace ChordView.iOS
{
	public class SQLite_iOS : ISQLite
	{
		private SQLiteConnection mConnection;
	
		public SQLite_iOS()
		{
			
		}

		public SQLiteConnection GetConnection()
		{
			if (mConnection == null)
			{
				var sqliteFilename = "BanglaChord.s3db";
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
				var dbPath = Path.Combine(libraryPath, sqliteFilename);

				// This is where we copy in the prepopulated database
				//Console.WriteLine(path);
				#if DEBUG
				if (File.Exists(dbPath))
				{
					File.Delete(dbPath);
				}
				#endif

				if (!File.Exists(dbPath))
				{
					var existingDb = NSBundle.MainBundle.PathForResource("BanglaChord", "s3db");
					File.Copy(existingDb, dbPath);
				}

				//syn version
				mConnection = new SQLiteConnection(new SQLitePlatformIOS(), dbPath);
				//async version
				//var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
				//	new SQLiteConnectionWithLock
				//	(
				//		new SQLitePlatformIOS(),
				//		new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)
				//	));

				//mConnection = new SQLiteAsyncConnection(connectionFunc);
			 }
			 // Return the database connection 
			return mConnection;
		 }

	}
}
