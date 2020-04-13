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
        private string userEmail;
        private string userPassword;

        public LoginPage()
        {
            databaseAccess = new DatabaseAccess();
            lVM = new LoginViewmodel();
            registerVM = new RegisterViewModel();
            hashing = new Hashing();
            userEmail = "";

            this.BindingContext = lVM;
            InitializeComponent();




        }

        private async void LoginButton_OnClicked(object sender, EventArgs e)
        {
            userEmail = LoginEmailEntry.Text;
            userPassword = LoginPasswordEntry.Text;
            user = lVM.GetUserFromDB(userEmail);

            if (user.Email.Equals(userEmail) && hashing.ValidateMD5Hash(userPassword, user.Password))
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