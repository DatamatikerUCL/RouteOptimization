using System;
using System.Collections.Generic;
using System.Text;

namespace RelateITWorking.Interfaces
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
