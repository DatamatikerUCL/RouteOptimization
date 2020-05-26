using RelateItNewest2605.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RelateItNewest2605.ViewModel
{
    class LoginViewmodel
    {
        private User user;
        private DatabaseAccess databaseAccess;
        private RegisterViewModel rVM;



        public LoginViewmodel()
        {
            databaseAccess = new DatabaseAccess();
            rVM = new RegisterViewModel();

        }

        public User GetUserFromDB(string email)
        {
            user = databaseAccess.GetUser(email);
            return user;
        }

        public User GetLatestRegistration()
        {
            user = databaseAccess.GetLatestRegistration();
            return user;
        }


    }
}
