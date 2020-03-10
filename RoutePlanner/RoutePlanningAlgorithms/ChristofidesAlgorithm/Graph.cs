using System;
using System.Collections.Generic;
using RouteOptimization.RoutePlanner.Datastructures;
using System.Linq;

namespace RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm
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

        public Graph ToMinimumWeightPerfectMatching()
        {
            List<Edge> edgesToMatch = Edges;
            List<double> weightsToMatch = Weights;
            List<Edge> matching = new List<Edge>();
            List<double> matchingWeight = new List<double>();
            Graph returnGraph = new Graph();

            while (edgesToMatch.Count > 0)
            {
                FindLightestEdge(edgesToMatch, weightsToMatch, out Edge tempEdge, out double tempWeight);
                
                matching.Add(tempEdge);
                matchingWeight.Add(tempWeight);

                edgesToMatch = RemoveEdgesFromNode(tempEdge.Start, edgesToMatch);
                edgesToMatch = RemoveEdgesFromNode(tempEdge.End, edgesToMatch);

                weightsToMatch.Remove(tempWeight);
            }

            returnGraph.Edges = matching;
            returnGraph.Weights = matchingWeight;
        
            return returnGraph;
        }

        private static List<Edge> RemoveEdgesFromNode(ILocateable point, List<Edge> edgesToMatch)
        {
            List<Edge> tempList = new List<Edge>(edgesToMatch);
            foreach (var item in edgesToMatch)
            {
                if (item.Start == point || item.End == point)
                {
                    tempList.Remove(item);
                }
            }
            
            return tempList;
        }

        private void FindLightestEdge(List<Edge> edgesToMatch,
                                      List<double> weightsToMatch,
                                      out Edge tempEdge,
                                      out double tempWeight)
        {
            int index = 0;
            int minWeightIndex = 0;
            double minWeight = int.MaxValue;
            
            foreach (double weight in weightsToMatch)
            {
                if (weight < minWeight)
                {
                    minWeight = weight;
                    minWeightIndex = index;
                }
                index++;
            }

            tempEdge = edgesToMatch[minWeightIndex];
            tempWeight = minWeight;
        }
    }
}