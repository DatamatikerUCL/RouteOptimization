using RelateIT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.Data
{
    public class UserDatebaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public UserDatebaseController()
        {
            database = SQLiteDatebase.GetConnection();
            database.CreateTable<User>();
        }

        public User GetUser(int id)
        {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().Where(user => user.ID == id).FirstOrDefault();
                }
            }
        }
        public User GetUser(string name)
        {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().Where(user => user.Username == name).FirstOrDefault();
                }
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.ID != 0)
                {
                    database.Update(user);
                    return user.ID;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
