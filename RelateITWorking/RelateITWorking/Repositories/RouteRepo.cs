using RelateIT.Interfaces;
using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelateIT.Repositories
{
    public class RouteRepo : IDataAccessable
    {
        public RouteRepo()
        {

        }

        private static readonly object padLock = new object();
        private static RouteRepo instance = null;
        public static RouteRepo GetInstance
        {
            get
            {
                lock (padLock)
                {
                    if( instance == null)
                    {
                        instance = new RouteRepo();
                    }
                    return instance;
                }
            }
        }

        public List<Route> GetRoutes()
        {
            throw new NotImplementedException();
        }
    }
}
