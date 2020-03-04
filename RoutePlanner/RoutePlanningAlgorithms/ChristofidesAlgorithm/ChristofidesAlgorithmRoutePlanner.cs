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
            MinimumSpanningTree minimumRouteTree = CreateMinimumSpanningTree(route);

            throw new System.NotImplementedException();
        }

        private MinimumSpanningTree CreateMinimumSpanningTree(IPlannable route)
        {
            int amountOfVertexes = route.LocationCount;

            AdjacencyMatrix routeTree = new AdjacencyMatrix(route, _calculator);

            return Prim.PrimMinimumSpanningTree(routeTree, amountOfVertexes, route.Locations);
        }
    }
}