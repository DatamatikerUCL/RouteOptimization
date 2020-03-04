using System;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm
{
    public class AdjacencyList
    {
        private readonly Interfaces.IDistanceCalculator _calculator;
        private ImmutableList<ImmutableList<double>> _matrix;
        public ImmutableList<ImmutableList<double>> Matrix { get => _matrix; }

        public AdjacencyList(IPlannable route, Interfaces.IDistanceCalculator calculator)
        {
            _calculator = calculator;

            SetupAdjacencyMatrix(route.Locations);
        }

        private void SetupAdjacencyMatrix(ImmutableList<ILocateable> locations)
        {
            _matrix = ImmutableList<ImmutableList<double>>.Empty;
            
            for (int i = 0; i < locations.Count; i++)
            {
                ImmutableList<double> tempList = ImmutableList<double>.Empty;

                for (int j = 0; j < locations.Count; j++)
                {
                    tempList = tempList.Add(CalculateWeight(locations[i], locations[j]));
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
    }

}