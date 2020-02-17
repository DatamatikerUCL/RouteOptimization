using System;
using System.Collections.Generic;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public class UnorderedRoute : Route
    {
        public UnorderedRoute() : base()
        {
        }

        public UnorderedRoute(Location location, List<Location> locations) : base(location, locations)
        {
        }
    }
}