using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Datastructures
{
    public class OrderedRoute : Route
    {

        public OrderedRoute()
        {
        }

        public OrderedRoute(ImmutableList<ILocateable> path) : base(path[0], path.Remove(path[0]))
        {
        }

        public OrderedRoute(ILocateable startLocation, ImmutableList<ILocateable> locations) : base(startLocation, locations)
        {
        }

        public object GetLocation(int i)
        {
            return Locations[i];
        }
    }
}