using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Datastructures
{
    public abstract class Route
    {
        protected Route()
        {
            Locations = ImmutableList<ILocateable>.Empty;
        }

        protected Route(ILocateable startLocation, ImmutableList<ILocateable> locations)
        {

            Locations = ImmutableList<ILocateable>.Empty.Add(startLocation);

            foreach (var location in locations)
            {
                Locations = Locations.Add(location);
            }
            

        }

        public ILocateable StartLocation => Locations[0];
        public ImmutableList<ILocateable> Locations { get; }

        public int LocationsCount => Locations.Count;
    }
}