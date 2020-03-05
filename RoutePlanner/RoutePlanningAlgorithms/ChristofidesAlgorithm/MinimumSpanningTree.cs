using System;
using System.Collections.Generic;
using RouteOptimization.RoutePlanner.Datastructures;
using System.Linq;

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

        public List<ILocateable> GetVertexesWithOddDegrees()
        {
            int degreeCount = 0;
            List<ILocateable> locationsWithOddDegree = new List<ILocateable>();
            List<ILocateable> locations = GetDistinctLocations();

            foreach (ILocateable location in locations)
            {
                degreeCount += (from item in Edges
                                where location == item.Start || location == item.End
                                select item).Count();

                if (degreeCount % 2 != 0)
                {
                    locationsWithOddDegree.Add(location);
                }

                degreeCount = 0;
            }

            return locationsWithOddDegree;
        }

        private List<ILocateable> GetDistinctLocations()
        {
            List<ILocateable> distinctLocations = new List<ILocateable>();

            foreach (Edge item in Edges)
            {
                if (!distinctLocations.Contains(item.Start))
                {
                    distinctLocations.Add(item.Start);
                }
                if (!distinctLocations.Contains(item.End))
                {
                    distinctLocations.Add(item.End);
                }
            }

            return distinctLocations;
        }
    }
}