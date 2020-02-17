using System.Collections.Generic;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public abstract class Route
    {
        protected Route()
        {
            Locations = new List<Location>();
        }

        protected Route(Location startLocation, List<Location> locations)
        {
            if (locations == null)
            {
                Locations = new List<Location>();
            }
            else
            {
                Locations = locations;
            }
            Locations.Insert(0, startLocation);
        }

        public Location StartLocation {get => Locations[0]; }
        public List<Location> Locations {get; }

        public int LocationsCount { get => Locations.Count; }

        internal Location GetLocation(int i)
        {
            return Locations[i];
        }
    }
}