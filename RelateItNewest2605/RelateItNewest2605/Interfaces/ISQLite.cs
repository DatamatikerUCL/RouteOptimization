using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace RelateItNewest2605.Interfaces
{
    public interface ISQLite
    {
        Microsoft.Data.Sqlite.SqliteConnection GetConnection();
    }
}
