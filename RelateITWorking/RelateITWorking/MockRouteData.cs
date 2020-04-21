using RelateIT.Interfaces;
using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateITWorking
{
    public class MockRouteData : IDataAccessable
    {

        ImmutableList<Route> routes;
        ImmutableList<ILocateable> locations;


        public MockRouteData()
        {
            routes = ImmutableList<Route>.Empty;
            locations = ImmutableList<ILocateable>.Empty;
        }

        public Route CreateRoute(string _name)
        {

            Location location1 = new Location(55.4211854, 10.3507287, "Bogensevej 105");
            Location location3 = new Location(55.473220, 10.330290, "Lufthavnvej 130");
            locations = locations.Add(location1);
            locations = locations.Add(location3);


            Route route = new Route(_name, locations, locations.Count, locations[0], DateTime.Now, 5.0);

            return route;
        }
        public ImmutableList<Route> GetRoutes()
        {
            routes = routes.Add(CreateRoute("firstRoute"));
            return routes;

        }

    }
}
