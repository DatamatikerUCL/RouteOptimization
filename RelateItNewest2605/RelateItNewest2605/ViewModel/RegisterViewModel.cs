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
    public class RegisterViewModel
    {


        public Action DisplayInvalidRegistrationPrompt;
        public Action DisplayValidRegistrationPrompt;
        public DatabaseAccess databaseAccess;




        public RegisterViewModel()
        {
            databaseAccess = new DatabaseAccess();

        }

        public void RegisterUser(User user)
        {
            databaseAccess.AddUser(user);
        }





    }
}
