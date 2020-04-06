using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Android.Database.Sqlite;
using SQLite;

namespace RelateITWorking
{
    public static class DatabaseConn
    {
        public const string DatabaseFilename = "Users.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
