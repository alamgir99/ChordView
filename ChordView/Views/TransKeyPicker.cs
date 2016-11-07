using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ChordView
{
	public class TransKeyPicker : ContentPage
	{
		public int mKeyValue { get; set;}

		public TransKeyPicker(int oldKey)
		{
			Label keyLabel = new Label() 
			{ 
				Text = "Choose new kew:",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand 
			};

			Picker keyPicker = new Picker
			{
				Title = "Choose key :",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			var options = new List<string> {
										"-5","-4","-3","-2","-1","0",
										"+1", "+2", "+3", "+4", "+5"
										};

			foreach(var item in options)
				keyPicker.Items.Add(item);

			keyPicker.SelectedIndex = oldKey+5;
			keyPicker.SelectedIndexChanged +=  async (sender, args) =>
			{
				mKeyValue = Int32.Parse(keyPicker.Items[keyPicker.SelectedIndex]);
				await Navigation.PopModalAsync();
			};


			StackLayout hLayout = new StackLayout();
			hLayout.Children.Add(keyLabel);
			hLayout.Children.Add(keyPicker);

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 5);

			this.Content = hLayout;
		}
	}
}
