using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanner
{
    public class TravellingSalesmanAlgorithmSelector
    {
        private readonly IDistanceCalculator _temp;

        public TravellingSalesmanAlgorithmSelector(IDistanceCalculator temp)
        {
            _temp = temp;
        }

        public IRoutePlanner GetOptimalAlgorithm()
        {
            return new NearestNeighbourRoutePlanner(_temp);
        }
    }
}
