using System;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanning.Datastructures;

namespace RouteOptimization.RoutePlanning.Interfaces
{
    public interface IRoutePlanner
    {
        IPlannable PlanRoute(IPlannable route, IPlannableFactory factory);
    }
}