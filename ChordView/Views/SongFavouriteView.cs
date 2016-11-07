using System;
using SQLite.Net;
using Xamarin.Forms;

namespace ChordView
{
	public class SongFavouriteView : ContentPage
	{
		public SongFavouriteView(SQLiteConnection dbConn)
		{
			Title = "Favourite Songs";

			Label homeLabel = new Label { Text = "Favourite song- wait till next version.", FontSize = 20 };

			var stackLout = new StackLayout { Children = { homeLabel } };

			this.Content = stackLout;
		}
	}
}
