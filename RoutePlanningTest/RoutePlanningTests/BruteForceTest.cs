using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RoutePlannerTest.InterfaceImplementations;
using RoutePlanning.RoutePlanningAlgorithms.BruteForce;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RoutePlanningTest.RoutePlanningTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class BruteForceTest
    {
        private readonly TestDistanceCalculator _distanceCalculator = new TestDistanceCalculator();
        private readonly TestPlannableFactory _testFactory = new TestPlannableFactory();
        private ImmutableList<ILocateable> _locations = ImmutableList<ILocateable>.Empty;
        private IPlannable _orderedRoute;
        private ILocateable _startLocation = new TestLocation();


        [TestInitialize]
        public void SetupLocations()
        {
            _startLocation = new TestLocation(0, 0);
            ILocateable locationOne = new TestLocation(1, 12);
            ILocateable locationTwo = new TestLocation(0, 2);
            ILocateable locationThree = new TestLocation(3, 4);
            ILocateable locationFour = new TestLocation(1, 1);
            ILocateable locationFive = new TestLocation(5,5);

            _locations = _locations.Add(locationOne); // 12.04
            _locations = _locations.Add(locationTwo); // 2
            _locations = _locations.Add(locationThree); // 3.6
            _locations = _locations.Add(locationFour); // 0
            _locations = _locations.Add(locationFive); // 7.07

            ImmutableList<ILocateable> locationsInOrder = ImmutableList<ILocateable>.Empty;
            locationsInOrder = locationsInOrder.Add(locationFour);
            locationsInOrder = locationsInOrder.Add(locationTwo);
            locationsInOrder = locationsInOrder.Add(locationThree);
            locationsInOrder = locationsInOrder.Add(locationFive);
            locationsInOrder = locationsInOrder.Add(locationOne);

            _orderedRoute = new TestPlannable(_startLocation, locationsInOrder);
        }

        [TestMethod]
        public void CreationTakesDistanceCalculator()
        {
            BruteForce temp = new BruteForce(_distanceCalculator);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void BruteForceClassImplementsIRoutePlanner()
        {
            BruteForce temp = new BruteForce(_distanceCalculator);

            Assert.IsInstanceOfType(temp, typeof(IRoutePlanner));
        }

        [TestMethod]
        public void RoutePlanningCorrectEndLocationTest()
        {
            BruteForce bruteForce = new BruteForce(_distanceCalculator);

            IPlannable routeToOrder = new TestPlannable(_startLocation, _locations);

            IPlannable returnRoute = bruteForce.PlanIPlannable(routeToOrder, _testFactory);

            Assert.AreEqual(_orderedRoute.Locations[^1], returnRoute.Locations[^1]);
        }
    }
}
