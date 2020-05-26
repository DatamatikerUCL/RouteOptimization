using RelateIT.Repositories;
using System;
using RelateITWorking;
using RelateITWorking.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateIT
{
    public partial class App : Application
    {
        public NavigationPage LoginPage { get; private set; }
        public static DatabaseAccess database;

        public static DatabaseAccess Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseAccess();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

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
