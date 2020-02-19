using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Interfaces
{
    public interface IRoutePlanner
    {
        OrderedRoute PlanRoute(UnorderedRoute route);
    }
}