using RelateIT.Repositories;
using RelateItNewest2605.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateItNewest2605.ViewModel
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
