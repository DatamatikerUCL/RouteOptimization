using RouteOptimization.RoutePlanning.Datastructures;
using System.Diagnostics.CodeAnalysis;

namespace RoutePlannerTest.InterfaceImplementations
{
    [ExcludeFromCodeCoverage]
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