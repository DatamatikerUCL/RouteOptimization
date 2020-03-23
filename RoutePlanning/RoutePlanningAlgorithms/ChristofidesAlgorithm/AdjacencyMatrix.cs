using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanning.Datastructures;

namespace RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm
{
    public class AdjacencyMatrix
    {
        private ImmutableList<ILocateable> _locations = ImmutableList<ILocateable>.Empty;
        private readonly Interfaces.IDistanceCalculator _calculator;
        private ImmutableList<ImmutableList<double>> _matrix;
        public ImmutableList<ImmutableList<double>> Matrix { get => _matrix; }

        public AdjacencyMatrix(IPlannable route, Interfaces.IDistanceCalculator calculator)
        {
            _locations = route.Locations;
            _calculator = calculator;

            SetupAdjacencyMatrix();
        }

        public AdjacencyMatrix(ImmutableList<ILocateable> locations, Interfaces.IDistanceCalculator calculator)
        {
            _locations = locations;
            _calculator = calculator;

            SetupAdjacencyMatrix();
        }

        private void SetupAdjacencyMatrix()
        {
            _matrix = ImmutableList<ImmutableList<double>>.Empty;
            
            for (int i = 0; i < _locations.Count; i++)
            {
                ImmutableList<double> tempList = ImmutableList<double>.Empty;

                for (int j = 0; j < _locations.Count; j++)
                {
                    tempList = tempList.Add(CalculateWeight(_locations[i], _locations[j]));
                }

                _matrix = _matrix.Add(ImmutableList<double>.Empty.AddRange(tempList));
            }
        }

        private double CalculateWeight(ILocateable locateable1, ILocateable locateable2)
        {
            if (locateable1.Latitude == locateable2.Latitude
            && locateable1.Longtitude == locateable2.Longtitude)
            {
                return 0;
            }
            else
            {
                return _calculator.CalculateDistanceBetweenLocations(locateable1, locateable2);
            }
        }
        public Graph ToGraph()
        {
            Graph returnGraph = new Graph();
            List<Edge> edges = new List<Edge>();
            List<double> weights = new List<double>();

            for (int i = 0; i < _matrix.Count; i++)
            {
                for (int j = i + 1; j < _matrix[i].Count; j++)
                {
                    edges.Add(new Edge(_locations[i], _locations[j]));
                    weights.Add(_matrix[i][j]);
                }
                
            }
            returnGraph.Edges = edges;
            returnGraph.Weights = weights;

            return returnGraph;
        }
    }

}