using RouteOptimization.RoutePlanning.Datastructures;

namespace RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.Graphs
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

        public ILocateable Start { get; }
        public ILocateable End {get; }
    }
}