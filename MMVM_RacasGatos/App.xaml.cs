using Xamarin.Forms;


namespace Cats
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			var content = new Cats.CatsPage();
			MainPage = new NavigationPage(content);

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
