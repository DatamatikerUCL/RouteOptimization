using RelateIT.Interfaces;
using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public ImmutableList<IPlannable> GetRoutes()
        {
            throw new NotImplementedException();
        }
    }
}
