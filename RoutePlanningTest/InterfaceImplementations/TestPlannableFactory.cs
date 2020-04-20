using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;

namespace RoutePlannerTest.InterfaceImplementations
{
    [ExcludeFromCodeCoverage]
    public class TestPlannableFactory : IPlannableFactory
    {
        public IPlannable NewIPlannable(ImmutableList<ILocateable> path)
        {
            return new TestPlannable(path);
        }

        public IPlannable NewIPlannable(ImmutableList<ILocateable> path, IDistanceCalculator distanceCalculator)
        {
            return new TestPlannable(path, distanceCalculator);
        }
    }
}