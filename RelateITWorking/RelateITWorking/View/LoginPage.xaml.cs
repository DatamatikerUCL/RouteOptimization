using System;
using RelateIT;
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

        public LoginPage()
        {
            databaseAccess = new DatabaseAccess();
            lVM = new LoginViewmodel();
            registerVM = new RegisterViewModel();
            this.BindingContext = lVM;
            InitializeComponent();
            user = lVM.GetLatestRegistration();


        }

        private async void LoginButton_OnClicked(object sender, EventArgs e)
        {

            if (user.Email.Equals(Email.Text) && user.Password.Equals(Password.Text))
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