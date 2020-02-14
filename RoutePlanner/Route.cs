using System.Collections.Generic;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public abstract class Route
    {
        protected Route()
        {
        }

        protected Route(Location startLocation, List<Location> locations)
        {
            StartLocation = startLocation;
            Locations = locations;
        }

        public Location StartLocation {get; }
        public List<Location> Locations {get; }
    }
}