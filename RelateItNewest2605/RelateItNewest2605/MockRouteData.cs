
using RelateItNewest2605.Interfaces;
using RelateItNewest2605.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateItNewest2605
{
    public class MockRouteData : IDataAccessable
    {

        ImmutableList<RelateItNewest2605.Models.Route> routes;
        ImmutableList<ILocateable> locations;


        public MockRouteData()
        {
            routes = ImmutableList<RelateItNewest2605.Models.Route>.Empty;
            locations = ImmutableList<ILocateable>.Empty;
        }

        public RelateItNewest2605.Models.Route CreateRoute(string _name)
        {

            Location location1 = new Location(55.4211854, 10.3507287, "Bogensevej 105");
            Location location3 = new Location(55.473220, 10.330290, "Lufthavnvej 130");
            locations = locations.Add(location1);
            locations = locations.Add(location3);


            RelateItNewest2605.Models.Route route = new RelateItNewest2605.Models.Route(_name, locations, locations.Count, locations[0], DateTime.Now, 5.0);

            return route;
        }


        ImmutableList<RelateItNewest2605.Models.Route> IDataAccessable.GetRoutes()
        {
            routes = routes.Add(CreateRoute("firstRoute"));
            return routes;
        }
    }
}
