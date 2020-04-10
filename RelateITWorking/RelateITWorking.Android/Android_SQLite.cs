using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RelateITWorking.Droid;
using RelateITWorking.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Android_SQLite))]
namespace RelateITWorking.Droid
{
    public class Android_SQLite : ISQLite
    {
        // create connection to the db from android
        public SQLiteConnection GetConnection()
        {
            var dbName = "UsersAndroid.db";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = System.IO.Path.Combine(dbPath, dbName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}