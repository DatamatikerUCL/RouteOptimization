using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;

namespace RoutePlannerTest
{
    [TestClass]
    public class NearestNeighbourRoutePlannerTest
    {
        private List<Location> _locations = new List<Location>();
        private OrderedRoute _orderedRoute;
        private Location _startLocation = new Location();

        [TestInitialize]
        private void SetupLocations()
        {
            _startLocation = new Location("Test lokation 1", 0, 0);
            Location locationOne = new Location("", 1, 12);
            Location locationTwo = new Location("", 0, 2);
            Location locationThree = new Location("", 3, 4);

            _locations.Add(locationOne); // 12.04
            _locations.Add(locationTwo); // 2
            _locations.Add(locationThree); // 3.6

            List<Location> locationsInOrder = new List<Location>();
            locationsInOrder.Add(locationTwo);
            locationsInOrder.Add(locationThree);
            
            _orderedRoute = new OrderedRoute(_startLocation,locationOne, locationsInOrder);
        }
        
        [TestMethod]
        public void InheritanceTest()
        {
            NearestNeighbourRoutePlanner temp = new NearestNeighbourRoutePlanner();

            Assert.IsInstanceOfType(temp, typeof(IRoutePlanner));
        }

        [TestMethod]
        public void RoutePlannerTest()
        {
            NearestNeighbourRoutePlanner temp = new NearestNeighbourRoutePlanner();

            UnorderedRoute routeToOrder = new UnorderedRoute(_startLocation, _locations);

        }
    }
}