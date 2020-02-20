using RouteOptimization.RoutePlanner.Datastructures;

namespace RouteOptimization.RoutePlanner.Interfaces
{
    public interface IDistanceCalculator
    {
        double CalculateDistanceBetweenLocations(ILocateable firstLocation, ILocateable secondLocation);
    }
}