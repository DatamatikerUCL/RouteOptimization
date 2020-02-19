using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public class OrderedRoute : Route
    {

        public OrderedRoute()
        {
        }

        public OrderedRoute(ImmutableList<Location> path) : base(path[0], path)
        {
        }

        public OrderedRoute(Location startLocation, ImmutableList<Location> locations) : base(startLocation, locations)
        {
        }

        public Location EndLocation { get => Locations[^1]; set => Locations = Locations.Add(value); }
    }
}