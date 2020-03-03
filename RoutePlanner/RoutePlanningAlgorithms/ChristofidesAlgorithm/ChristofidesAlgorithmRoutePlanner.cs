using System;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;

namespace RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm
{
    public class ChristofidesAlgorithmRoutePlanner : IRoutePlanner
    {
        private readonly IDistanceCalculator _calculator;
        public ChristofidesAlgorithmRoutePlanner(IDistanceCalculator calculator)
        {
            _calculator = calculator;
        }

        public IPlannable PlanRoute(IPlannable route, IPlannableFactory factory)
        {
            AdjacencyList minimumRouteTree = MinimumSpanningTree(route);

            throw new System.NotImplementedException();
        }

        private AdjacencyList MinimumSpanningTree(IPlannable route)
        {
            AdjacencyList routeTree = new AdjacencyList(route, _calculator);         
            throw new NotImplementedException();
        }
    }
}