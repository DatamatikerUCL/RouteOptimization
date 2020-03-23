using RouteOptimization.RoutePlanning.Datastructures;

namespace RouteOptimization.RoutePlanning.Interfaces
{
    public interface IDistanceCalculator
    {
        double CalculateDistanceBetweenLocations(ILocateable firstLocation, ILocateable secondLocation);
    }
}