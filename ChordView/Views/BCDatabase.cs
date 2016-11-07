/**
 * 
 * 
 * Facilitates db access 
 * 
 **/


using System;
using SQLite.Net;
using SQLite.Net.Async;
using Xamarin.Forms;
using BanglaChord.DataModels;

namespace BanglaChord
{
	public class BCDatabase
	{
		//for locking purpose
		static object mPadLock = new object();
		SQLiteAsyncConnection mdbConn;


		public BCDatabase()
		{
			mdbConn = DependencyService.Get<ISQLite>().GetConnection(); 
		}



	}
}
