using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm
{
    public static class Prim
    {
        public static MinimumSpanningTree PrimMinimumSpanningTree(AdjacencyList routeTree, int amountOfVertexes, ImmutableList<ILocateable> locations)
        {
            int[] parent = new int[amountOfVertexes];
            double[] key = new double[amountOfVertexes];
            bool[] minimumSpanningTreeSet = new bool[amountOfVertexes];
            MinimumSpanningTree returnTree = new MinimumSpanningTree();

            for (int i = 0; i < amountOfVertexes; i++)
            {
                key[i] = int.MaxValue;
                minimumSpanningTreeSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < amountOfVertexes - 1; count++)
            {
                int minimumRemainingKey = FindMinKey(key, minimumSpanningTreeSet);
                minimumSpanningTreeSet[minimumRemainingKey] = true;

                for (int i = 0; i < amountOfVertexes; i++)
                {
                    if (routeTree.Matrix[minimumRemainingKey][i] != 0 && minimumSpanningTreeSet[i] == false
                    && routeTree.Matrix[minimumRemainingKey][i] < key[i])
                    {
                        parent[i] = minimumRemainingKey;
                        key[i] = routeTree.Matrix[minimumRemainingKey][i];
                    }
                }
            }

            for (int i = 0; i < amountOfVertexes; i++)
            {
                ILocateable startLocation = locations[parent[i]];
                ILocateable endLocation = locations[i];

                Edge newEdge = new Edge(startLocation, endLocation);
                double newWeight = key[i];

                returnTree.Edges.Add(newEdge);
                returnTree.Weights.Add(newWeight);

            }

            return returnTree;
        }

        private static int FindMinKey(double[] key, bool[] minimumSpanningTreeSet)
        {
            double min = int.MaxValue;
            int min_index = -1;

            for (int i = 0; i < key.Length; i++)
            {
                if (minimumSpanningTreeSet[i] == false && key[i] < min)
                {
                    min = key[i];
                    min_index = i;
                }
                
            }

            return min_index;
        }

    }
}