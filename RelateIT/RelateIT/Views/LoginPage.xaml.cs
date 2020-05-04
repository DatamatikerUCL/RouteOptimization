﻿using RelateIT.Models;
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
            Init();
        }

        protected override void OnAppearing()
        {
            Entry_Username.Text = string.Empty;
            Entry_Password.Text = string.Empty;
        }

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            lbl_Username.TextColor = Constants.MainTextColor;
            lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeigth;
            

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            //Entry_Password.Completed += (s, e) => Btn_Signin_Clicked(s,e);
        }

        async void Btn_Signin_Clicked(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            User tempUser = App.UserDatebase.GetUser(user.Username);
            if (tempUser != null && tempUser.Username == user.Username && tempUser.Password == user.Password)
            {
                await DisplayAlert("Login", "Login Success", "OK");
                await Navigation.PushAsync(new MainPage(user.ID));
                //Application.Current.MainPage = new NavigationPage(new MainPage(user.ID));
            }
            else
            {
               await DisplayAlert("Login Failed", "Password or Username is not correct", "OK");
            }
        }

        private void Btn_Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}