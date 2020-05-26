using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelateItNewest2605.Interfaces;
using RelateItNewest2605.Models;
using SQLite;
using Xamarin.Forms;

namespace RelateItNewest2605
{
    public class DatabaseAccess
    {

        private SQLiteConnection connection;

        //CREATE  
        public DatabaseAccess()
        {
            connection = DependencyService.Get<ISQLite>().GetConnection();
            connection.CreateTable<User>();
        }

        //READ  
        public IEnumerable<User> GetUsers()
        {
            var users = (from user in connection.Table<User>() select user);
            return users.ToList();
        }

        //READ
        public User GetUser(string email)
        {
            var user = (from tempUser in connection.Table<User>().Where(x => x.Email == email) select tempUser);
            return user.FirstOrDefault();
        }

        public User GetLatestRegistration()
        {
            var user = (from tempUser in connection.Table<User>() select tempUser);
            return user.LastOrDefault();
        }


        //INSERT  
        public string AddUser(User user)
        {
            connection.Insert(user);
            return "success";
        }
        //DELETE  
        public string DeleteUser(int id)
        {
            connection.Delete<User>(id);
            return "success";
        }
    }
}
