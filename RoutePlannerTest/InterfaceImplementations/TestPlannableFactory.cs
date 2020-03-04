using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;

namespace RoutePlannerTest.InterfaceImplementations
{
    public class TestPlannableFactory : IPlannableFactory
    {
        public IPlannable NewIPlannable(ImmutableList<ILocateable> path)
        {
            return new TestPlannable(path);
        }
    }
}