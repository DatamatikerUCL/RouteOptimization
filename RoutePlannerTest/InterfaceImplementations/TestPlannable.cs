using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RoutePlannerTest.InterfaceImplementations
{
    public class TestPlannable : IPlannable
    {
        public TestPlannable()
        {
            Locations = ImmutableList<ILocateable>.Empty;
        }
        public TestPlannable(ImmutableList<ILocateable> path)
        {
            Locations = path;
        }

        public TestPlannable(ILocateable startLocation, ImmutableList<ILocateable> locations)
        {
            Locations = ImmutableList<ILocateable>.Empty.Add(startLocation);
            Locations = Locations.AddRange(locations);
        }

        public ImmutableList<ILocateable> Locations {get; }

        public ILocateable StartLocation { get => Locations[0]; }
        public int LocationCount { get => Locations.Count; }
    }
}