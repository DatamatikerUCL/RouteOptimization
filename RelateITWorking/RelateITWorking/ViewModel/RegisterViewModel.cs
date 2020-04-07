using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using RelateITWorking.Models;
using Xamarin.Forms;

namespace RelateITWorking.ViewModel
{
    class RegisterViewModel
    {

        public Action DisplayInvalidRegistrationPrompt;
        public Action DisplayValidRegistrationPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public User user = new User();
        private string email;
        public string Email
        {
            get { return user.Email; }
            set
            {
                user.Email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand RegisterCommand { protected set; get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegister);
        }

        public void OnRegister()
        {
            if (!Email.Contains("@") || IsPassStrongEnough(Password))
            {
                DisplayInvalidRegistrationPrompt();
            }
            else
            {
                DisplayValidRegistrationPrompt();
            }
        }

        //will check if the password is atleast 6 characters long, has one digit, and one non-alphanumerical character
        public bool IsPassStrongEnough(string password)
        {
            return Regex.IsMatch(password, @"^.{6,}(?<=\d.*)(?<=[^a-zA-Z0-9].*)$");
        }
    }
}
