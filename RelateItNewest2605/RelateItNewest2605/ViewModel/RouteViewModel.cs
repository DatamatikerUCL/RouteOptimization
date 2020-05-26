using System;
using RelateIT.Repositories;
using RouteOptimization.RoutePlanner.Datastructures;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;
using Double = System.Double;
using RelateItNewest2605.Models;

namespace RelateItNewest2605.ViewModel
{
    public class RouteViewModel
    {
        private RouteRepo _routeRepo;
        private readonly RelateItNewest2605.Models.Route _route;

        public RouteViewModel(int routeId)
        {
            _routeRepo = RouteRepo.GetInstance();
            _route = _routeRepo.GetRoute(routeId);


        }

        public RouteViewModel()
        {

        }

        public RelateItNewest2605.Models.Route GetRoute()
        {
            return _route;
        }

        public Double GetLocationLatitude(int routeId)
        {
            return _route.Locations[routeId].Latitude;
        }

        public Double GetLocationLongitude(int routeId)
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

        public int GetRouteId()
        {
            return _route.Id;
        }
    }
}
