using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class NearestNeighbourRoutePlannerTest
    {
        private readonly IDistanceCalculator _testCalculator = new TestDistanceCalculator();
        private ImmutableList<ILocateable> _locations = ImmutableList<ILocateable>.Empty;
        private OrderedRoute _orderedRoute;
        private ILocateable _startLocation = new TestLocation();

        [TestInitialize]
        public void SetupLocations()
        {
            _startLocation = new TestLocation(0, 0);
            ILocateable locationOne = new TestLocation(1, 12);
            ILocateable locationTwo = new TestLocation(0, 2);
            ILocateable locationThree = new TestLocation(3, 4);

            _locations = _locations.Add(locationOne); // 12.04
            _locations =_locations.Add(locationTwo); // 2
            _locations = _locations.Add(locationThree); // 3.6

            ImmutableList<ILocateable> locationsInOrder = ImmutableList<ILocateable>.Empty;
            locationsInOrder = locationsInOrder.Add(locationTwo);
            locationsInOrder = locationsInOrder.Add(locationThree);
            locationsInOrder = locationsInOrder.Add(locationOne);
            
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

            Assert.AreEqual(route.GetLocation(2), _orderedRoute.GetLocation(2));

        }
    }
}