using System.Collections.Immutable;
using RouteOptimization.RoutePlanning.Datastructures;

namespace RouteOptimization.RoutePlanning.Interfaces
{
    public interface IPlannableFactory
    {
        IPlannable NewIPlannable(ImmutableList<ILocateable> path);
    }
}