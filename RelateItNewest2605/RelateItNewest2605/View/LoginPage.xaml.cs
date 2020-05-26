﻿using System;
using RelateIT;
using RelateItNewest2605.Models;
using RelateItNewest2605.ViewModel;
using RelateITWorking.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateItNewest2605.View
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
            NavigationPage.SetHasBackButton(this, false);
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

            try
            {
                if (user.Email.Equals(userEmail) && hashing.ValidateMD5Hash(userPassword, user.Password))
                {
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    DisplayAlert("Error", "Username or Password was wrong try again", "OK");
                }
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
                await DisplayAlert("Error", "Email is wrong please try with another", "OK");
            }


        }

        private async void RegisterButton_OnClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new RegisterPage());
        }



    }
}