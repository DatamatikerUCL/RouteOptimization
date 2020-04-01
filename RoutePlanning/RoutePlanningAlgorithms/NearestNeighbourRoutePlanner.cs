using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using System;
using System.Collections.Immutable;

namespace RouteOptimization.RoutePlanning.RoutePlanningAlgorithms
{
    public class NearestNeighbourRoutePlanner : IRoutePlanner
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public NearestNeighbourRoutePlanner(IDistanceCalculator calculator)
        {
            _distanceCalculator = calculator;
        }

        public IPlannable PlanIPlannable(IPlannable route, IPlannableFactory factory)
        {
            ILocateable current = route.StartLocation;
            ImmutableList<ILocateable> remaining = route.Locations.Remove(route.StartLocation);
            ImmutableList<ILocateable> path = ImmutableList<ILocateable>.Empty.Add(route.StartLocation);

            while (!remaining.IsEmpty) 
            {
                ILocateable next = Closest(current, remaining);
                path = path.Add(next);

                remaining = remaining.Remove(next);

                current = next;
            }

            return factory.NewIPlannable(path);
        }

        private ILocateable Closest(ILocateable current, ImmutableList<ILocateable> remaining)
        {
            double tolerance = 0.01;
            double smallestDistance = 0;
            ILocateable nextLocation = current;

            foreach (ILocateable location in remaining)
            {
                double tempDistance = _distanceCalculator.CalculateDistanceBetweenILocateables(current, location);
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