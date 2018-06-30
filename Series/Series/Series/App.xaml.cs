using Series.Services.Navigation;
using Series.ViewModel.Base;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Series
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            buildDependencies();
            initNavigation();
		}

        private async void initNavigation()
        {
            var navigation = ViewModelLocator.Instance.Resolve<INavigationService>();
            await navigation.Initialize();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void buildDependencies()
        {
            ViewModelLocator.Instance.Build();
        }
	}
}
