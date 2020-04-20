using RouteOptimization.RoutePlanning.Interfaces;
using System.Collections.Immutable;

namespace RouteOptimization.RoutePlanning.Datastructures
{
    public interface IPlannable
    {
        public ImmutableList<ILocateable> Locations { get; }

        public ILocateable StartLocation { get; }

        public int LocationCount { get; }
        public double TotalLength(IDistanceCalculator distanceCalculator);
    }
}