using System;
using RelateIT.Models;
using RelateIT.Repositories;
using RouteOptimization.RoutePlanner.Datastructures;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;
using Java.Lang;
using Double = System.Double;
using Exception = Java.Lang.Exception;

namespace RelateITWorking.ViewModel
{
    public class RouteViewModel
    {
        private RouteRepo _routeRepo;
        private readonly Route _route;

        public RouteViewModel(int routeId)
        {
            _route = _routeRepo.GetRoute(routeId);
            _routeRepo = RouteRepo.GetInstance();

        }

        public RouteViewModel()
        {
        }

        public Route GetRoute()
        {
            return _route;
        }

        public Double GetRouteLatitude(int routeId)
        {
            return _route.Locations[routeId].Latitude;
        }

        public Double GetRouteLongitude(int routeId)
        {
            return _route.Locations[routeId].Longtitude;
        }

        public string GetRouteName()
        {
            return _route.Name;
        }

        public string GetRouteAdress(int locationId)
        {
            Location tempLocation;
            if (_route.Locations[locationId] is Location)
            {
                tempLocation = (Location)_route.Locations[locationId];
                return tempLocation.Adress;
            }

            throw new InvalidDataException("Not the right data");
        }
    }
}
