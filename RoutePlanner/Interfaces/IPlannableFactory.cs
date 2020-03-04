using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Interfaces
{
    public interface IPlannableFactory
    {
        IPlannable NewIPlannable(ImmutableList<ILocateable> path);
    }
}