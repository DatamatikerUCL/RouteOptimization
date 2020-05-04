using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.ViewModels
{
    public class UserViewModel
    {
        private User user;
        private User checkUser;
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserViewModel(string username, string password, int ID = 0)
        {
            Username = username;
            Password = password;
        }
        internal UserViewModel CreateUser(string name, string password)
        {
            checkUser = new User(name, password);
            return new UserViewModel(name, password);
        }

        internal UserViewModel GetUser()
        {
            user = App.UserDatebase.GetUser(checkUser.Username);
            return new UserViewModel(checkUser.Username, checkUser.Password, checkUser.ID);
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
