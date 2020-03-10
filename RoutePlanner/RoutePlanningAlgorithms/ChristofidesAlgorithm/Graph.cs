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

                RemoveEdgesAndWeightsFromNode(tempEdge.Start,
                                              edgesToMatch,
                                              weightsToMatch,
                                              out edgesToMatch,
                                              out weightsToMatch);

                RemoveEdgesAndWeightsFromNode(tempEdge.End,
                                              edgesToMatch,
                                              weightsToMatch,
                                              out edgesToMatch,
                                              out weightsToMatch);
            }

            returnGraph.Edges = matching;
            returnGraph.Weights = matchingWeight;
        
            return returnGraph;
        }

        private static void RemoveEdgesAndWeightsFromNode(ILocateable point,
                                                          List<Edge> edgesToMatch,
                                                          List<double> weightsToMatch,
                                                          out List<Edge> returnEdges,
                                                          out List<double> returnWeights)
        {
            int index = 0;
            List<Edge> tempEdges = new List<Edge>(edgesToMatch);
            List<double> tempWeights = new List<double>();

            foreach (var item in edgesToMatch)
            {
                if (item.Start == point || item.End == point)
                {
                    tempEdges.Remove(item);
                    tempWeights.Add(weightsToMatch[index]);
                }

                index++;
            }

            returnEdges = tempEdges;
            returnWeights = weightsToMatch.Except(tempWeights).ToList();

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