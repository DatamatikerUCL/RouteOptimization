using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Btn_Signin_Clicked(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                await DisplayAlert("Login", "Login Success", "OK");
                Application.Current.MainPage = new AppShell();
            }
            else
            {
               await DisplayAlert("Login", "Login not correct, empty username or password", "OK");
            }
        }
    }
}