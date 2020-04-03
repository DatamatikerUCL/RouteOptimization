using RelateIT.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using RelateIT.Models;

namespace RelateITWorking.ViewModel
{

    class RouteOverviewViewModel
    {
        private RouteRepo _routeRepo;
        private readonly ImmutableList<Route> _routes;

        public RouteOverviewViewModel()
        {
            _routeRepo = RouteRepo.GetInstance();
            _routes = _routeRepo.GetRoutes();
        }

        public ImmutableList<Route> GetRoutes()
        {
            return _routes;
        }

    }
}
