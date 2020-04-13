using System;
using RelateIT;
using RelateITWorking.Helpers;
using RelateITWorking.Models;
using RelateITWorking.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateITWorking.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private DatabaseAccess databaseAccess;
        private User user;
        private RegisterViewModel registerVM;
        private LoginViewmodel lVM;
        private Hashing hashing;

        public LoginPage()
        {
            databaseAccess = new DatabaseAccess();
            lVM = new LoginViewmodel();
            registerVM = new RegisterViewModel();
            hashing = new Hashing();
            this.BindingContext = lVM;
            InitializeComponent();
            user = lVM.GetLatestRegistration();


        }

        private async void LoginButton_OnClicked(object sender, EventArgs e)
        {

            if (user.Email.Equals(Email.Text) && hashing.ValidateMD5Hash(Password.Text, user.Password))
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Error", "Username or Password was wrong try again", "OK");
            }

        }

        private async void RegisterButton_OnClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());
        }



    }
}