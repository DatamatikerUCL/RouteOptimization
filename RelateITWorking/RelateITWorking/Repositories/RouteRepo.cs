using RelateIT.Interfaces;
using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using RelateITWorking;

namespace RelateIT.Repositories
{
    public class RouteRepo : IDataAccessable
    {
        private readonly IDataAccessable _dataAcesser;
        private ImmutableList<IPlannable> routes;
        private RouteRepo(IDataAccessable dataAccesser)
        {
            _dataAcesser = dataAccesser;
            routes = _dataAcesser.GetRoutes();
        }

        private static readonly object padLock = new object();
        private static RouteRepo instance = null;
        public static RouteRepo GetInstance(IDataAccessable dataAcesser = null)
        {
            lock (padLock)
            {
                if (dataAcesser == null && instance == null)
                {
                    throw new NullReferenceException();
                }
                if (instance == null)
                {
                    instance = new RouteRepo(dataAcesser);
                }
                return instance;
            }
        }

        public ImmutableList<IPlannable> GetRoutes()
        {
            return routes;
        }
    }
}
