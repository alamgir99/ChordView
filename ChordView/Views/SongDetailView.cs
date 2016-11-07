using System;
using Xamarin.Forms;
using SQLite.Net;
using ChordView.DataModels;
using ChordView.Helpers;

namespace ChordView
{
	public class SongDetailView : ContentPage
	{
		//transposition key
		public int mTKey { get; set; }

		public SongDetailView(SQLiteConnection dbConn, int songid)
		{
			SongDataProvider prov = new SongDataProvider(dbConn, null);
			Songs aSong = prov.GetSong(songid);

			Title = aSong.Title + "-" + aSong.Artist;
			mTKey = 0;

			//TODO: transposition
			/*
			ToolbarItems.Add(new ToolbarItem("Fav", "fav.png", async () => 
				{
				await Navigation.PushModalAsync(new TransKeyPicker(mTKey)); 
				}));
			*/

			ChordTabParser crdParser = new ChordTabParser(aSong.SongText, mTKey);

			var fontSize = 0;
			var fontSrc = "";
			if (Device.OS == TargetPlatform.iOS) { 
				fontSize = 23; 
				fontSrc = "url('HindSiliguri-Regular.otf')"; 
			}
			else if (Device.OS == TargetPlatform.Android) { 
				fontSize = 25; //(int)Device.GetNamedSize(NamedSize.Small, typeof(Label)); 
				fontSrc = "url('HindSiliguri-Regular.ttf')";
			}

			string preHtml = "<!DOCTYPE HTML> <html> <head>" +
				"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"/> "+
				"<style type=\"text/css\"> @font-face {" +
						"font-family:HindSiliguri;" +
				"src:"+fontSrc+" ;}" +
				" p { font-family:HindSiliguri; font-size:"+ fontSize +"px; }" +
				"div#songDetail { padding-top:0px; display:block; text-align:left; height:auto;width:100%;}" +
				".SVGsongView {padding-top:0; height:auto; width:99%;}" +
				"</style></head>" +
						"<body> <div id=\"songDetail\"><p>";

			string parsedChord = crdParser.Parse();

			string postHtml = "</p></div></body></html>";

			string wholeHtml = preHtml + parsedChord + postHtml;

			WebView webView = new WebView
			{

				Source = new HtmlWebViewSource
				{
					Html = wholeHtml
				},
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Aqua
			};


			// Accomodate iPhone status bar.
			this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 5);

			// Build the page.
			this.Content = webView;
		}
	}
}
