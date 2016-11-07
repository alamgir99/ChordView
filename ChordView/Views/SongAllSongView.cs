using System;
using ChordView.DataModels;
using SQLite.Net;
using Xamarin.Forms;

namespace ChordView
{
	public class SongAllSongView : ContentPage
	{
		public SongAllSongView(SQLiteConnection dbConn)
		{
			Title = "All Songs";
		

			SongDataProvider prov = new SongDataProvider(dbConn, null);

			ListView songList = new ListView();
			songList.ItemTemplate = new DataTemplate(typeof(CustomCellView));

			songList.ItemsSource = prov.GetSongInfoList();
			songList.ItemTapped += async (sender, e) => {
				if (e.Item == null) return;
				//await DisplayAlert("Song selected", e.Item.ToString(), "Ok");
				SongMeta sm = (SongMeta)e.Item;
				await Navigation.PushAsync(new SongDetailView(dbConn, sm.SongId));
				((ListView)sender).SelectedItem = null;
			
			};


			this.Content = songList;
		}

		public class CustomCellView : ViewCell {
			public CustomCellView() {
				var songIdLabel = new Label();
				var titleLabel = new BNLabel() { VerticalOptions = LayoutOptions.Center};
				var artistLabel = new BNLabel() {VerticalOptions = LayoutOptions.Center };
				var spacer = new Label { Text = "-" };

				var hLayout = new StackLayout();

				//set bindings
				songIdLabel.SetBinding(Label.TextProperty, new Binding("SongId"));
				titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
				artistLabel.SetBinding(Label.TextProperty, new Binding("Artist"));

				//desired design
				hLayout.Orientation = StackOrientation.Horizontal;
				hLayout.HorizontalOptions = LayoutOptions.Fill;
				hLayout.VerticalOptions = LayoutOptions.CenterAndExpand;


				var font = Device.OnPlatform(
					"HindSiliguri-Regular",
					"HindSiliguri-Regular.ttf",
					null
				);

				//customize font
				if (Device.OS == TargetPlatform.iOS)
				{
					titleLabel.FontFamily = font;
					artistLabel.FontFamily = font;
				}
				else if (Device.OS == TargetPlatform.Android) 
				{
					titleLabel.BNFontFamily = font;
					artistLabel.BNFontFamily = font;
				}

				titleLabel.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
				artistLabel.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
	
				//TODO: add to favourite
				/*
				//fav button
				Button favBtn = new ListButton()
				{
					Text = "+Fav",
					UserData = songIdLabel.Text,
					HorizontalOptions = LayoutOptions.EndAndExpand,
					VerticalOptions = LayoutOptions.Center

				};

				favBtn.Clicked += (sender, e) =>
				{
					//int sId = Int32.Parse(((ListButton)sender).UserData);
					//App.Current.MainPage.Navigation.PushAsync(new AddToFavPage(sId));
					//Navigation.PushModalAsync(new TransKeyPicker(mTKey));
					string msg = ((ListButton)sender).UserData;
					App.Current.MainPage.DisplayAlert("Title", "Adding to fav: " + msg, "ok");
				};

				*/

				//add all elements to the layout
				//hLayout.Children.Add(songIdLabel);
				//hLayout.Children.Add(spacer);
				hLayout.Children.Add(titleLabel);
				hLayout.Children.Add(spacer);
				hLayout.Children.Add(artistLabel);
				//hLayout.Children.Add(favBtn);

				//padding around the screen
				hLayout.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
				//add to parent view
				View = hLayout;
				
			}
		}
	}
}
