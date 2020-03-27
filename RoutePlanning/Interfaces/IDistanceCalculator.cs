using RouteOptimization.RoutePlanning.Datastructures;

namespace RouteOptimization.RoutePlanning.Interfaces
{
    public interface IDistanceCalculator
    {
        double CalculateDistanceBetweenILocateables(ILocateable firstLocateable, ILocateable secondLocateable);
    }
}