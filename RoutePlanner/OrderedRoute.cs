using System.Collections.Generic;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public class OrderedRoute : Route
    {
        public OrderedRoute(Location startLocation, Location endLocation, List<Location> locations) : base(startLocation, locations)
        {
            EndLocation = endLocation;
        }

        public Location EndLocation { get; set; }
    }
}