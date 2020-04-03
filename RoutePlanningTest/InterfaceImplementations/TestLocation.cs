using RouteOptimization.RoutePlanning.Datastructures;

namespace RoutePlannerTest.InterfaceImplementations
{
    public class TestLocation : ILocateable
    {
        public TestLocation(double latitude = double.NegativeInfinity, double longtitude = double.NegativeInfinity)
        {
            Latitude = latitude;
            Longtitude = longtitude;
        }
        public double Latitude {get; }

        public double Longtitude {get; }
    }

}