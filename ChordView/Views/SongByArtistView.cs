using System;
using SQLite.Net;
using Xamarin.Forms;
using ChordView.DataModels;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ChordView
{


	public class SongByArtistView : ContentPage
	{
		public SongByArtistView(SQLiteConnection dbConn)
		{
			Title = "Songs By Artist";

			SongDataProvider prov = new SongDataProvider(dbConn, null);

			ListView songList = new ListView();
			songList.ItemTemplate = new DataTemplate(typeof(CustomCellView));

			var songs = prov.GetSongInfoList();
			var songsByArtist = from s in songs
								group s by s.Artist into g
								orderby g.Key
								select g;


			ObservableCollection<GroupedSongMeta> grouped = new ObservableCollection<GroupedSongMeta>();

			foreach (var grp in songsByArtist)
			{
				GroupedSongMeta gsm = new GroupedSongMeta();
				gsm.GroupHeader = grp.Key;
				foreach (SongMeta sm in grp)
				{
					gsm.Add(sm);
				}
				grouped.Add(gsm);
			}

			songList.ItemsSource = grouped;
			songList.IsGroupingEnabled = true;
			songList.GroupDisplayBinding = new Binding("GroupHeader");
			songList.GroupHeaderTemplate = null;
			songList.ItemTapped += async (sender, e) =>
			{
				if (e.Item == null) return;
					SongMeta sm = (SongMeta)e.Item;
				await Navigation.PushAsync(new SongDetailView(dbConn, sm.SongId));
				((ListView)sender).SelectedItem = null;

			};

				this.Content = songList;
		}

		public class CustomCellView : ViewCell
		{
			public CustomCellView()
			{
				var titleLabel = new BNLabel();
				var albumLabel = new BNLabel();
				var hLayout = new StackLayout();
				var spacer = new Label { Text = "-" };

				//set bindings
				titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
				albumLabel.SetBinding(Label.TextProperty, new Binding("Album"));
	
				var font = Device.OnPlatform(
					"HindSiliguri-Regular",
					"HindSiliguri-Regular.ttf",
					null
				);

				//customize font
				if (Device.OS == TargetPlatform.iOS)
				{
					titleLabel.FontFamily = font;
					albumLabel.FontFamily = font;
				}
				else if (Device.OS == TargetPlatform.Android)
				{
					titleLabel.BNFontFamily = font;
					albumLabel.BNFontFamily = font;
				}

				titleLabel.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
				albumLabel.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));


				//desired design
				hLayout.Orientation = StackOrientation.Horizontal;
				hLayout.HorizontalOptions = LayoutOptions.Fill;
				hLayout.VerticalOptions = LayoutOptions.CenterAndExpand;



				hLayout.Children.Add(titleLabel);
				hLayout.Children.Add(spacer);
				hLayout.Children.Add(albumLabel);

				//padding around the screen
				hLayout.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);;
				//add to parent view
				View = hLayout;

			}
		}
	}
}
