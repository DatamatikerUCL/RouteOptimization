//using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace RelateIT.Data
{
    public static class SQLiteDatebase
    {
        //SQLiteConnection GetConnection();
        public static SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";           
            var path = Path.Combine(FileSystem.AppDataDirectory, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
        
    }
}
