/**
 * Adds a song to favourite
 * 
 * TODO: access the fav list and display real status of the song being added
 * */

using System;
using Xamarin.Forms;
using SQLite.Net;


namespace ChordView
{
	public class AddToFavPage : ContentPage
	{
		public AddToFavPage(int songid)
		{
			Label fav1Label = new Label { Text = "Favourite 1 :", HorizontalOptions = LayoutOptions.StartAndExpand };
			Switch fav1Switch = new Switch { HorizontalOptions = LayoutOptions.End };
			fav1Switch.Toggled += (sender, e) => { UpdateFavourite(1, songid); };

			StackLayout fav1 = new StackLayout
			{
				Children = { fav1Label, fav1Switch },
				Orientation = StackOrientation.Horizontal
			};

			Label fav2Label = new Label { Text = "Favourite 2 :", HorizontalOptions = LayoutOptions.StartAndExpand };
			Switch fav2Switch = new Switch { HorizontalOptions = LayoutOptions.End };
			fav2Switch.Toggled += (sender, e) => { UpdateFavourite(2, songid); };

			StackLayout fav2 = new StackLayout
			{
				Children = { fav2Label, fav2Switch },
				Orientation = StackOrientation.Horizontal
			};

			Label fav3Label = new Label { Text = "Favourite 3 :", HorizontalOptions = LayoutOptions.StartAndExpand };
			Switch fav3Switch = new Switch { HorizontalOptions = LayoutOptions.End };
			fav3Switch.Toggled += (sender, e) => { UpdateFavourite(3, songid); };

			StackLayout fav3 = new StackLayout
			{
				Children = { fav3Label, fav3Switch },
				Orientation = StackOrientation.Horizontal
			};
			Label fav4Label = new Label { Text = "Favourite 4 :", HorizontalOptions = LayoutOptions.StartAndExpand };
			Switch fav4Switch = new Switch { HorizontalOptions = LayoutOptions.End };
			fav4Switch.Toggled += (sender, e) => { UpdateFavourite(4, songid); };

			StackLayout fav4 = new StackLayout
			{
				Children = { fav4Label, fav4Switch },
				Orientation = StackOrientation.Horizontal
			};

			Label fav5Label = new Label { Text = "Favourite 5 :", HorizontalOptions = LayoutOptions.StartAndExpand };
			Switch fav5Switch = new Switch { HorizontalOptions = LayoutOptions.End };
			fav5Switch.Toggled += (sender, e) => { UpdateFavourite(5, songid); };

			StackLayout fav5 = new StackLayout
			{
				Children = { fav5Label, fav5Switch },
				Orientation = StackOrientation.Horizontal
			};

			Button okButton = new Button { Text = "   Ok   ", HorizontalOptions = LayoutOptions.CenterAndExpand, 
				BorderWidth = 1, BorderRadius = 5};
			okButton.Clicked += async (sender, e) => { await Navigation.PopModalAsync();};


			this.Padding = new Thickness { Top = 20, Left = 10, Right = 10};
			this.Content = new StackLayout
			{
				Children = { fav1, fav2, fav3, fav4, fav5, okButton }
			};
		}

		public void UpdateFavourite(int favNo, int songid)
		{ }

	}
}
