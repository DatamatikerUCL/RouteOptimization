using System;
using System.Collections.Immutable;
using System.Linq;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;

namespace RoutePlannerTest.InterfaceImplementations
{
    public class TestPlannable : IPlannable
    {
        private readonly IDistanceCalculator _distanceCalculator;
        public TestPlannable()
        {
            Locations = ImmutableList<ILocateable>.Empty;
        }
        public TestPlannable(ImmutableList<ILocateable> path)
        {
            Locations = path;
        }

        public TestPlannable(ImmutableList<ILocateable> path, IDistanceCalculator distanceCalculator)
        {
            Locations = path;
            _distanceCalculator = distanceCalculator;
        }

        public TestPlannable(ILocateable startLocation, ImmutableList<ILocateable> locations)
        {
            Locations = ImmutableList<ILocateable>.Empty.Add(startLocation);
            Locations = Locations.AddRange(locations);
        }

        public ImmutableList<ILocateable> Locations {get; }

        public ILocateable StartLocation { get => Locations[0]; }
        public int LocationCount { get => Locations.Count; }

        public double TotalLength()
        {
            double totalLength = 0;

            for (int i = 0; i < Locations.Count-1; i++)
            {
                totalLength += _distanceCalculator.CalculateDistanceBetweenILocateables(Locations[i], Locations[i + 1]);
            }

            return totalLength;
        }
    }
}