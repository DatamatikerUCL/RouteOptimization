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
using RelateIT.Data;
using SQLite;

namespace RelateIT.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {

        }
        public SQLiteConnection GetConnection()
        {
            var sqliteFireName = "TestDB.db3";
            string documentPrath = System.Environment.GetFolderPath
        }
        
    }
}