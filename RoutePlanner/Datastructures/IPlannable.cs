using System.Collections.Immutable;

namespace RouteOptimization.RoutePlanner.Datastructures
{
    public interface IPlannable
    {
        public ImmutableList<ILocateable> Locations { get; }

        public ILocateable StartLocation { get; }

        public int LocationCount { get; }
    }
}