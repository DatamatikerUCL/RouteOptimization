using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanning.RoutePlanningAlgorithms.BruteForce
{
    public class BruteForce : IRoutePlanner
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public BruteForce(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        public IPlannable PlanIPlannable(IPlannable plannable, IPlannableFactory factory)
        {
            throw new NotImplementedException();
        }
    }
}
