using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.Graphs;

namespace RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm
{
    public class ChristofidesAlgorithmRoutePlanner : IRoutePlanner
    {
        private readonly IDistanceCalculator _calculator;
        public ChristofidesAlgorithmRoutePlanner(IDistanceCalculator calculator)
        {
            _calculator = calculator;
        }

        public IPlannable PlanIPlannable(IPlannable route, IPlannableFactory factory)
        {
            Graph minimumRouteTree = CreateMinimumSpanningTree(route);
            Graph perfectMatching = CalculatePerfectMatching(minimumRouteTree);
            
            Graph multiGraph = minimumRouteTree.CombineGraph(perfectMatching);

            throw new System.NotImplementedException();
        }

        private Graph CalculatePerfectMatching(Graph minimumRouteTree)
        {
            List<ILocateable> oddDegreeLocations = minimumRouteTree.GetVertexesWithOddDegrees();
            AdjacencyMatrix subAdjacencyMatrix = new AdjacencyMatrix(oddDegreeLocations.ToImmutableList(), _calculator);

            Graph subGraph = subAdjacencyMatrix.ToGraph();

            return PerfectMatching.BlossomLeastWeight(subGraph);
        }

        private Graph CreateMinimumSpanningTree(IPlannable route)
        {
            int amountOfVertexes = route.LocationCount;

            AdjacencyMatrix routeTree = new AdjacencyMatrix(route, _calculator);

            return Prim.PrimMinimumSpanningTree(routeTree, amountOfVertexes, route.Locations);
        }
    }
}