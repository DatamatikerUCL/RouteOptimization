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
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(FileSystem.AppDataDirectory, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
        
    }
}
