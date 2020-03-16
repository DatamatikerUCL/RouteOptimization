using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.Interfaces
{
    interface IDataAccessable
    {

        List<Route> GetRoutes();
    }
}
