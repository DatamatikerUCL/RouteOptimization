using System;
using Microsoft.Data.Sqlite;
using RelateItNewest2605.Droid;
using RelateItNewest2605.Interfaces;
using RelateITWorking.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Android_SQLite))]
namespace RelateITWorking.Droid
{
    public class Android_SQLite : ISQLite
    {
        // create connection to the db from android
        SqliteConnection ISQLite.GetConnection()
        {
            var dbName = "UsersAndroid.db";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(dbPath, dbName);
            var conn = new Microsoft.Data.Sqlite.SqliteConnection(path);
            return conn;
        }
    }
}