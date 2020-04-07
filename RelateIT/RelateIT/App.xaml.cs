using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RelateIT.Views;
using RelateIT.Data;

namespace RelateIT
{
    public partial class App : Application
    {
        static TokenDataBaseController tokenDatabase;
        static UserDatebaseController userDatebase;
        public App()
        {
            InitializeComponent();           
            MainPage = new NavigationPage(new MainPage());
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

        public static UserDatebaseController UserDatebase
        {
            get
            {
                if (userDatebase == null)
                {
                    userDatebase = new UserDatebaseController();
                }
                return userDatebase;
            }
        }

        public static TokenDataBaseController TokenDataBase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDataBaseController();
                }
                return tokenDatabase;
            }
        }
    }
}
