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

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.RegisterCommand.Execute(null);
            };
        }

        public async void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            await databaseAccess.SaveItemAsync(user);
            await Navigation.PushAsync(new MainPage());

        }
    }
}