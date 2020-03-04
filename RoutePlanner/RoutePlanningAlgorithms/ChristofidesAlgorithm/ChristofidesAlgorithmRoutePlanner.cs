using System;
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
            MinimumSpanningTree minimumRouteTree = CreateMinimumSpanningTree(route);

            throw new System.NotImplementedException();
        }

        private MinimumSpanningTree CreateMinimumSpanningTree(IPlannable route)
        {
            int amountOfVertexes = route.LocationCount;

            AdjacencyList routeTree = new AdjacencyList(route, _calculator);

            return PrimMinimumSpanningTree(routeTree, amountOfVertexes);
        }

        private MinimumSpanningTree PrimMinimumSpanningTree(AdjacencyList routeTree, int amountOfVertexes)
        {
            int[] parent = new int[amountOfVertexes];
            double[] key = new double[amountOfVertexes];
            bool[] minimumSpanningTreeSet = new bool[amountOfVertexes];

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

            throw new NotImplementedException();
        }

        private int FindMinKey(double[] key, bool[] minimumSpanningTreeSet)
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