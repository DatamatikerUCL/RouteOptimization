using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Datastructures
{
    public class UnorderedRoute : Route
    {
        public UnorderedRoute()
        {
        }

        public UnorderedRoute(ILocateable startLocation, ImmutableList<ILocateable> locations) : base(startLocation, locations)
        {
        }
    }
}