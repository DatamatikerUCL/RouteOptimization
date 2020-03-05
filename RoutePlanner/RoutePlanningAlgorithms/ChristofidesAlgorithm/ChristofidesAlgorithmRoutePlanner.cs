using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            Graph minimumRouteTree = CreateMinimumSpanningTree(route);

            List<ILocateable> oddDegreeLocations = minimumRouteTree.GetVertexesWithOddDegrees();

            AdjacencyMatrix subGraph = new AdjacencyMatrix(oddDegreeLocations.ToImmutableList(), _calculator);

            Graph minimumWeightPerfectMatching = subGraph.GetMinimumWeightPerfectMatching();

            throw new System.NotImplementedException();
        }

        private Graph CreateMinimumSpanningTree(IPlannable route)
        {
            int amountOfVertexes = route.LocationCount;

            AdjacencyMatrix routeTree = new AdjacencyMatrix(route, _calculator);

            return Prim.PrimMinimumSpanningTree(routeTree, amountOfVertexes, route.Locations);
        }
    }
}