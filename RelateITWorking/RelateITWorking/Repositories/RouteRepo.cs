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
        private ImmutableList<Route> routes;
        private RouteRepo(IDataAccessable dataAccesser)
        {
            _dataAcesser = dataAccesser;
            routes = (ImmutableList<Route>)_dataAcesser.GetRoutes();
        }

        private static readonly object padLock = new object();
        private static RouteRepo instance;
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

        public ImmutableList<Route> GetRoutes()
        {
            return routes;
        }

        internal Route GetRoute(int id)
        {
            return routes.Find(route => route.Id == id);
        }

    }
}
