using System;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Interfaces
{
    public interface IRoutePlanner
    {
        IPlannable PlanRoute(IPlannable route, IPlannableFactory factory);
    }
}