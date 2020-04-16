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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BackgroundColor = Constants.BackgroundColor;
            lbl_Username.TextColor = Constants.MainTextColor;
            lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeigth;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            //Entry_Password.Completed +=  (s, e) => Btn_Create_Clicked(s, e);
        }

        async void Btn_Create_Clicked(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            User tempUser = App.UserDatebase.GetUser(user.Username);
            if (tempUser == null)
            {
                await DisplayAlert("Succes", "Account succesful created", "OK");
                App.UserDatebase.SaveUser(user);
                await Navigation.PopAsync();            
            }
            else
            {
                await DisplayAlert("Unsuccesful", "User already exist in the system try another username", "OK");
            }
            
        }
    }
}