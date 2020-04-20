using System;
using System.Collections.Generic;
using RouteOptimization.RoutePlanning.Datastructures;
using System.Linq;
using System.Collections.Immutable;

namespace RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.Graphs
{
    public class Graph
    {
        public List<Edge> Edges { get; set; }
        public List<double> Weights { get; set; }

        public Graph()
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

        internal ImmutableList<ILocateable> GetOrderedLocations()
        {
            //OrderEdgesByWeight();

            ImmutableList<ILocateable> orderedLocations = ImmutableList<ILocateable>.Empty;
            foreach (Edge edge in Edges)
            {
                orderedLocations = AddDistinctLocationsInEdge(orderedLocations, edge);
            }

            return orderedLocations;
        }

        private void OrderEdgesByWeight()
        {
            Edges = Edges.OrderBy(e => e.Weight).ToList();
        }

        private ImmutableList<ILocateable> AddDistinctLocationsInEdge(ImmutableList<ILocateable> orderedLocations, Edge edge)
        {
            if (!orderedLocations.Contains(edge.Start))
            {
                orderedLocations = orderedLocations.Add(edge.Start);
            }
            if (!orderedLocations.Contains(edge.End))
            {
                orderedLocations = orderedLocations.Add(edge.End);
            }

            return orderedLocations;
        }

        public Graph CombineGraph(Graph graphTwo)
        {
            Graph graphToReturn = new Graph();

            graphToReturn.Edges.AddRange(this.Edges);
            graphToReturn.Edges.AddRange(graphTwo.Edges);

            graphToReturn.Weights.AddRange(this.Weights);
            graphToReturn.Weights.AddRange(graphTwo.Weights);

            return graphToReturn;
        }
    }
}