using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using RelateITWorking.Interfaces;
using RelateITWorking.UWP;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Windows_SQLite))]
namespace RelateITWorking.UWP
{

    public class Windows_SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "UserWindows.db";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
