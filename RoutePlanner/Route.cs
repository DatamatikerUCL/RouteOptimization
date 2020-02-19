using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public abstract class Route
    {
        protected Route()
        {
            Locations = ImmutableList<Location>.Empty;
        }

        protected Route(Location startLocation, ImmutableList<Location> locations)
        {

            Locations = ImmutableList<Location>.Empty.Add(startLocation);

            foreach (var location in locations)
            {
                Locations = Locations.Add(location);
            }
            

        }

        public Location StartLocation => Locations[0];
        public ImmutableList<Location> Locations { get; }

        public int LocationsCount => Locations.Count;
    }
}