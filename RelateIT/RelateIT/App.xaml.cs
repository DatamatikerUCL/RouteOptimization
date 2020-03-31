using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RelateIT.Services;
using RelateIT.Views;

namespace RelateIT
{
    public partial class App : Application
    {
        private static UserDateBase database;
        public static UserDateBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDateBase();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
