using System.Collections.Generic;

namespace RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm
{
    public class MinimumSpanningTree
    {
        public List<Edge> Edges { get; set; }
        public List<double> Weights { get; set; }

        public MinimumSpanningTree()
        {
            Edges = new List<Edge>();
            Weights = new List<double>();
        }
    }
}