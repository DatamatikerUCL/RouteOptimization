using System.Collections.Generic;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public class OrderedRoute : Route
    {
        public OrderedRoute() : base()
        {
        }

        public OrderedRoute(Location startLocation, List<Location> locations) : base(startLocation, locations)
        {
        }

        public Location EndLocation { get => Locations[Locations.Count - 1]; set => Locations.Add(value); }
    }
}