using RelateIT.Models;
using RelateIT.ViewModels;
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
        private UserViewModel userViewModel; 
        public LoginPage()
        {
            InitializeComponent();
            userViewModel = new UserViewModel();
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
            UserViewModel checkuser = userViewModel.CreateUser(Entry_Username.Text, Entry_Password.Text);
            UserViewModel user = userViewModel.GetUser();
                //App.UserDatebase.GetUser(user.Username);
            if (userViewModel.CheckUsers())
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