using SQLite;
using SQLite.Net;
using Xamarin.Forms;

namespace ChordView
{
	public partial class App : Application
	{
		static SQLiteConnection mdbConn;

		public App()
		{
			InitializeComponent();

			mdbConn = DependencyService.Get<ISQLite>().GetConnection();
			MainPage = new NavigationPage(new MainViewPage(mdbConn));
		}


		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
