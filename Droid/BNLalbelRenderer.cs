using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using ChordView;

[assembly: ExportRenderer(typeof(BNLabel), typeof(BNLalbelRenderer))]

namespace ChordView
{
	public class BNLalbelRenderer : LabelRenderer
	{
		
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			var bnLabel = (BNLabel)Element;

			if (bnLabel.BNFontFamily != null)
			{
				Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, bnLabel.BNFontFamily);
				Control.Typeface = font;
			
			}
		}

	}
}
