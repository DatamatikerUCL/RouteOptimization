using System.Collections.Immutable;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;

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