using RouteOptimization.RoutePlanning.Datastructures;

namespace RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.Graphs
{
    public class Edge
    {
        public Edge()
        {
        }
        public Edge(ILocateable startLocation, ILocateable endLocation, double weight)
        {
            Start = startLocation;
            End = endLocation;
            Weight = weight;
        }

        public ILocateable Start { get; }
        public ILocateable End {get; }
        public double Weight { get; }
    }
}