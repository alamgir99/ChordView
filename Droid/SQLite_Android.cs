using System;
using ChordView;
using Xamarin.Forms;
using System.IO;
using ChordView.Droid;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(SQLite_Android))]

namespace ChordView.Droid 
{
	public class SQLite_Android : ISQLite
	{
		private SQLiteConnection mConnection;

		public SQLite_Android()
		{
		}


		public SQLiteConnection GetConnection()
		{
			if (mConnection == null)
			{
				var sqliteFilename = "BanglaChord.s3db";
				string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
				var dbPath = Path.Combine(documentsPath, sqliteFilename);

				// This is where we copy in the prepopulated database
				//Console.WriteLine(dbPath);
				#if DEBUG
				if (File.Exists(dbPath))
				{
					File.Delete(dbPath);
				}
				#endif
				//if (!File.Exists(dbPath))
				{
					using (var br = new BinaryReader(Forms.Context.Assets.Open("BanglaChord.s3db")))
					{
						using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
						{
							byte[] buffer = new byte[2048];
							int length = 0;
							while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
							{
								bw.Write(buffer, 0, length);
							}
						}
					}
				}

				//var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
				//syn version
				mConnection = new SQLiteConnection(new SQLitePlatformAndroid(), dbPath);
				//async version
				//var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
				//	new SQLiteConnectionWithLock
				//	(new SQLitePlatformAndroid(),
				//		new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)
				//	));

				//mConnection = new SQLiteAsyncConnection(connectionFunc);
			}
			// Return the database connection 
			return mConnection;

			}
	}
}
