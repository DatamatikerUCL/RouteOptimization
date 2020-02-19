using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;

namespace RoutePlannerTest
{
    [TestClass]
    public class NearestNeighbourRoutePlannerTest
    {
        private IDistanceCalculator _testCalculator = new TestDistanceCalculator();
        private ImmutableList<Location> _locations = ImmutableList<Location>.Empty;
        private OrderedRoute _orderedRoute;
        private Location _startLocation = new Location();

        [TestInitialize]
        public void SetupLocations()
        {
            _startLocation = new Location("Test lokation 1", 0, 0);
            Location locationOne = new Location("", 1, 12);
            Location locationTwo = new Location("", 0, 2);
            Location locationThree = new Location("", 3, 4);

            _locations.Add(locationOne); // 12.04
            _locations.Add(locationTwo); // 2
            _locations.Add(locationThree); // 3.6

            ImmutableList<Location> locationsInOrder = ImmutableList<Location>.Empty;
            locationsInOrder.Add(locationTwo);
            locationsInOrder.Add(locationThree);
            locationsInOrder.Add(locationOne);
            
            _orderedRoute = new OrderedRoute(_startLocation, locationsInOrder);
        }
        
        [TestMethod]
        public void InheritanceTest()
        {
            NearestNeighbourRoutePlanner temp = new NearestNeighbourRoutePlanner(_testCalculator);

            Assert.IsInstanceOfType(temp, typeof(IRoutePlanner));
        }

        [TestMethod]
        public void RoutePlannerCorrectEndLocationTest()
        {
            NearestNeighbourRoutePlanner temp = new NearestNeighbourRoutePlanner(_testCalculator);

            UnorderedRoute routeToOrder = new UnorderedRoute(_startLocation, _locations);

            OrderedRoute route = temp.PlanRoute(routeToOrder);

            Assert.AreEqual(route.EndLocation, _orderedRoute.EndLocation);

        }
    }
}