using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ChordView.Droid;
using ChordView;

[assembly: ExportRenderer (typeof (ListButton), typeof (ListButtonRenderer))]

namespace ChordView.Droid
{
	public class ListButtonRenderer : ButtonRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			Control.Focusable = false;
		}
	}
}