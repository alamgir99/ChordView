using System;
using SQLite.Net;
using Xamarin.Forms;

namespace ChordView
{
	public class SongUpdateView : ContentPage
	{
		public SongUpdateView(SQLiteConnection dbConn)
		{
			Title = "Song Update";

			Label homeLabel = new Label { Text = "Web Update- wait till next version.", FontSize = 20 };

			var stackLout = new StackLayout { Children = { homeLabel } };

			this.Content = stackLout;
		}
	}
}
