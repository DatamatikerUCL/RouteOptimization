using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner
{
    public abstract class Route
    {
        private ImmutableList<Location> _locations;

        protected Route()
        {
            Locations = ImmutableList<Location>.Empty;
        }

        protected Route(Location startLocation, ImmutableList<Location> locations)
        {

            Locations = ImmutableList<Location>.Empty.Add(startLocation);
            Locations = Locations.AddRange(locations);
            
        }

        public Location StartLocation => Locations[0];
        public ImmutableList<Location> Locations
        {
            get => _locations;
            set => _locations = value;
        }

        public int LocationsCount => Locations.Count;

        internal Location GetLocation(int i)
        {
            return Locations[i];
        }
    }
}