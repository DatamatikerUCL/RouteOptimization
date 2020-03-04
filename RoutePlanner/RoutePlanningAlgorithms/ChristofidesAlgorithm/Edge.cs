using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm
{
    public class Edge
    {
        public Edge()
        {
        }
        public Edge(ILocateable startLocation, ILocateable endLocation)
        {
            Start = startLocation;
            End = endLocation;
        }

        public ILocateable Start { get; set; }
        public ILocateable End {get; set; }
    }
}