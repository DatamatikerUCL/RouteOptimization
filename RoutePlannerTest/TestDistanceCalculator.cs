using System;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;

namespace RoutePlannerTest
{
    public class TestDistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistanceBetweenLocations(Location firstLocation, Location secondLocation)
        {
            double firstDistance = CalculateDistanceFromZero(firstLocation.Longtitude, firstLocation.Latitude);
            double secondDistance = CalculateDistanceFromZero(secondLocation.Longtitude, secondLocation.Latitude);
            return Math.Abs(secondDistance - firstDistance);
        }

        private double CalculateDistanceFromZero(double firstCoordinate, double secondCoordinate)
        {
            return Math.Sqrt(Math.Pow(firstCoordinate, 2) + Math.Pow(secondCoordinate, 2));
        }
    }
}