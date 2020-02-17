using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Interfaces
{
    public interface IDistanceCalculator
    {
        double CalculateDistanceBetweenLocations(Location firstLocation, Location secondLocation);
    }
}