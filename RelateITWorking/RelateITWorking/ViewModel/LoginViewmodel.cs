using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using RelateITWorking.Models;
using Xamarin.Forms;

namespace RelateITWorking.ViewModel
{
    class LoginViewmodel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
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

        public ICommand SubmitCommand { protected set; get; }

        public LoginViewmodel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            if (Email != "kasper-hoffmann@hotmail.com" || Password != "!QAZ2wsx")
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}
