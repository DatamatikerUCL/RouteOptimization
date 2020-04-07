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

        public LoginPage()
        {
            databaseAccess = new DatabaseAccess();
            var LoginVm = new LoginViewmodel();
            registerVM = new RegisterViewModel();
            this.BindingContext = LoginVm;
            LoginVm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                LoginVm.SubmitCommand.Execute(null);
            };

        }


        private async void LoginButton_OnClicked(object sender, EventArgs e)
        {
            user = (User)databaseAccess.GetUser(registerVM.user.Email);
            if (user.Email.Equals(Email.Text) && user.Password == Password.Text)
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