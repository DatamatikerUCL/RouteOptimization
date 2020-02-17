using System;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;

namespace RouteOptimization.RoutePlanner
{
    public class NearestNeighbourRoutePlanner : IRoutePlanner
    {
        IDistanceCalculator _distanceCalculator;

        public NearestNeighbourRoutePlanner(IDistanceCalculator calculator)
        {
            _distanceCalculator = calculator;
        }
        public OrderedRoute PlanRoute(UnorderedRoute routeToPlan)
        {
            AdjacencyMatrix matrix = CreateAdjacencyMatrix(routeToPlan);
            matrix = AddWeightsToMatrix(matrix, routeToPlan);

            throw new NotImplementedException();
        }

        private AdjacencyMatrix AddWeightsToMatrix(AdjacencyMatrix matrix, UnorderedRoute routeToPlan)
        {
            for (int i = 0; i < routeToPlan.LocationsCount; i++)
            {
                for (int j = 0; j < routeToPlan.LocationsCount; j++)
                {
                    if (i != j)
                    {
                        double tempWeight = _distanceCalculator.CalculateDistanceBetweenLocations(routeToPlan.GetLocation(i), routeToPlan.GetLocation(j));
                        matrix.ChangeWeightAtCoordinates(i, j, tempWeight);
                    }
                }
            }

            return matrix;
        }

        private AdjacencyMatrix CreateAdjacencyMatrix(UnorderedRoute routeToPlan)
        {
            return new AdjacencyMatrix(routeToPlan.LocationsCount);
        }
    }
}