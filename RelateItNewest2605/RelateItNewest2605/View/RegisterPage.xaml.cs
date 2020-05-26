using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RelateIT;
using RelateItNewest2605.Models;
using RelateItNewest2605.ViewModel;
using RelateITWorking.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateItNewest2605.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public DatabaseAccess databaseAccess;
        public User user;
        public RegisterViewModel vm;
        private Hashing hashing;
        private string email;
        private string password;
        public RegisterPage()
        {

            vm = new RegisterViewModel();
            hashing = new Hashing();
            this.BindingContext = vm;

            vm.DisplayInvalidRegistrationPrompt += () => DisplayAlert("Error", "Invalid Register, try again", "OK");
            vm.DisplayValidRegistrationPrompt += () => DisplayAlert("Success", "Registration completed", "OK");
            InitializeComponent();


        }

        public async void RegisterPageButton_OnClicked(object sender, EventArgs e)
        {
            OnRegister();
            await Navigation.PushAsync(new LoginPage());

        }

        //will check if the password is atleast 6 characters long, has one digit, and one non-alphanumerical character

        public bool IsPassStrongEnough(string password)
        {
            return Regex.IsMatch(password, @"^.{6,}(?<=\d.*)(?<=[^a-zA-Z0-9].*)$");
        }

        public void OnRegister()
        {

            user = new User();
            user.Email = EmailEntry.Text;
            email = user.Email;
            user.Password = PasswordEntry.Text;
            password = user.Password;
            if (IsPassStrongEnough(password))

            {
                string hashedPassword = hashing.ComputeMD5Hash(password);
                user.Password = hashedPassword;
            }
            else
            {
                DisplayAlert("Error", "Password is not strong enough, try using a symbol, numbers and letters", "OK");
            }


            if (!email.Contains("@"))
            {
                DisplayAlert("Error", "Email og password in wrong format", "OK");
            }
            else
            {
                vm.RegisterUser(user);
                DisplayAlert("Success", "User Registeret correctly", "OK");

            }
        }
    }
}