using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ChordView.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			//change title font
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				Font = UIFont.FromName("HindSiliguri-Regular", 20)
			});

			//prevent screen off
			UIApplication.SharedApplication.IdleTimerDisabled = true;

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
