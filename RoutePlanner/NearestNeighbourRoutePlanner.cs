using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;
using System;
using System.Collections.Immutable;

namespace RouteOptimization.RoutePlanner
{
    public class NearestNeighbourRoutePlanner : IRoutePlanner
    {
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly IPlannableFactory _iPlannableFactory;

        public NearestNeighbourRoutePlanner(IDistanceCalculator calculator, IPlannableFactory factory)
        {
            _distanceCalculator = calculator;
            _iPlannableFactory = factory;
        }

        public IPlannable PlanRoute(IPlannable route)
        {
            var current = route.StartLocation;
            var remaining = route.Locations.Remove(route.StartLocation);
            var path = ImmutableList<ILocateable>.Empty.Add(route.StartLocation);

            while (!remaining.IsEmpty) 
            {
                var next = Closest(current, remaining);
                path = path.Add(next);

                remaining = remaining.Remove(next);

                current = next;
            }

            return _iPlannableFactory.NewIPlannable(path);
        }

        private ILocateable Closest(ILocateable current, ImmutableList<ILocateable> remaining)
        {
            double tolerance = 0.01;
            double smallestDistance = 0;
            ILocateable nextLocation = current;

            foreach (var location in remaining)
            {
                double tempDistance = _distanceCalculator.CalculateDistanceBetweenLocations(current, location);
                if (tempDistance < smallestDistance || Math.Abs(smallestDistance) < tolerance)
                {
                    smallestDistance = tempDistance;
                    nextLocation = location;
                }
            }

            return nextLocation;
        }
    }
}