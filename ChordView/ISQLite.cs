/***
 * 
 * Defines sqlite interface 
 * 
 * 
 */

using System;
using SQLite;
using SQLite.Net;

namespace ChordView
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
