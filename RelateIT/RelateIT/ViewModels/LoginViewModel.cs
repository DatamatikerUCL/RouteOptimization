using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.ViewModels
{
    public class LoginViewModel
    {
        private User user;
        private User checkUser;
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
   
        internal void CreateUser(string name, string password)
        {
            checkUser = new User(name, password);            
        }

        internal User GetUser()
        {
            user = App.UserDatebase.GetUser(checkUser.Username);
            return user;
        }

        internal bool CheckUsers()
        {
            if (user != null && user.Username == checkUser.Username && user.Password == checkUser.Password)
            {
                return true;
            }
            return false;
        }
    }
}
