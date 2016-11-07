/**
 *  This the main view class of the app.
 *  Upon run, this screen is shown where users
 *  choose one of the few options.
 * 
 *  
 * */


using System;
using SQLite.Net;
using Xamarin.Forms;

namespace ChordView
{
	public class MainViewPage : ContentPage
	{
		public MainViewPage(SQLiteConnection dbConn)
		{
			Label mainLabel = new Label
			{
				Text = "BanglaChord ChordView",
				FontSize = 20, HorizontalOptions =  LayoutOptions.Center
			};
			Label subLabel = new Label { 
				Text = "Version 1.0", 
				FontSize = 15, 
				HorizontalOptions=LayoutOptions.Center
			};

			/*
			Label webLink = new Label { 
				Text = "http://www.banglachord.com/", 
				FontSize=10,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			TapGestureRecognizer tapGesture = new TapGestureRecognizer();
			webLink.GestureRecogniser.Add(tapGesture);
			*/


			// All Songs Button
			Button allSongs = new Button
			{
				Text = " All Songs ",
				BorderWidth = 1,
				BorderRadius = 5,
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			allSongs.Clicked += async (sender, e) => {
				await Navigation.PushAsync(new SongAllSongView(dbConn));
			};

			// By Artist button
			Button byArtistButton = new Button
			{
				Text = " By Artist ",
				BorderWidth = 1,
				BorderRadius = 5,
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			//click handler
			byArtistButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new SongByArtistView(dbConn));
			};

			//By Album button
			Button byAlbumButton = new Button
			{
				Text = " By Album ",
				BorderWidth = 1,
				BorderRadius = 5,
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			//click handler
			byAlbumButton.Clicked += async (sender, e) => { 
				await Navigation.PushAsync(new SongByAlbumView(dbConn));
			};

			//Favourite button
			Button favButton = new Button { 
				Text = " Favourites ",
				BorderWidth = 1,
				BorderRadius = 5,
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			//click handler
			favButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new SongFavouriteView(dbConn));
			};

			//update button
			Button updateButton = new Button
			{
				Text = " Web Update ... ",
				BorderWidth = 1,
				BorderRadius = 5,
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			//click handler
			updateButton.Clicked += async (sender, e) => { 
				await Navigation.PushAsync(new SongUpdateView(dbConn));
			};


			//layout these buttons
			StackLayout layout = new StackLayout
			{
				Padding = new Thickness(0, 30, 0, 0),
				Spacing = 15,
				Orientation = StackOrientation.Vertical,
				Children = { mainLabel, subLabel, allSongs, byArtistButton, byAlbumButton, favButton, updateButton }
			};

			//padding around the screen
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			//set the layout as content of the page
			this.Content = layout;

		}
	}
}
