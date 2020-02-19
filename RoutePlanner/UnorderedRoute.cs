using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public class UnorderedRoute : Route
    {
        public UnorderedRoute()
        {
        }

        public UnorderedRoute(Location location, ImmutableList<Location> locations) : base(location, locations)
        {
        }
    }
}