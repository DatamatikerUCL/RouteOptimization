using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelateIT;
using RelateITWorking.Models;
using RelateITWorking.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateITWorking.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public DatabaseAccess databaseAccess;
        public User user;
        public RegisterPage()
        {

            var vm = new RegisterViewModel();
            this.BindingContext = vm;

            vm.DisplayInvalidRegistrationPrompt += () => DisplayAlert("Error", "Invalid Register, try again", "OK");
            vm.DisplayValidRegistrationPrompt += () => DisplayAlert("Success", "Registration completed", "OK");
            InitializeComponent();


        }

        public void InsertUser()
        {
            user = new User();
            databaseAccess = new DatabaseAccess();
            user.Email = Email.Text;
            user.Password = Password.Text;
            databaseAccess.AddUser(user);
        }

        public async void RegisterPageButton_OnClicked(object sender, EventArgs e)
        {
            InsertUser();
            await Navigation.PushAsync(new LoginPage());

        }
    }
}