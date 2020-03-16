using RelateIT.Models;
using RelateIT.Repositories;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateITWorking.ViewModel
{
    public class RouteViewModel
    {
        private RouteRepo routeRepo = RouteRepo.GetInstance;
        private ImmutableList<IPlannable> routes = ImmutableList<IPlannable>.Empty;


        public ImmutableList<IPlannable> GetRoutes()
        {
            return routes = routeRepo.GetRoutes();
        }
    }
}
