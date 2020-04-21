using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using RelateITWorking.Interfaces;
using RelateITWorking.Models;
using SQLite;
using Xamarin.Forms;

namespace RelateITWorking
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

        //READ UNSAFE
        public IEnumerable<User> GetUsersUnSafe(string input)
        {
            var users = connection.Query<User>("SELECT * FROM User WHERE Email = '" + input + "'");

            return users;
        }

        //READ
        public User GetUser(string email)
        {
            var users = (from tempUser in connection.Table<User>().Where(x => x.Email == email) select tempUser);
            return users.FirstOrDefault();
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
