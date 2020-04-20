using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RoutePlannerTest.InterfaceImplementations;
using System.Diagnostics.CodeAnalysis;

namespace RoutePlannerTest.RoutePlanningTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class NearestNeighbourRoutePlannerTest
    {
        private readonly IDistanceCalculator _testCalculator = new TestDistanceCalculator();
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

            _locations = _locations.Add(locationOne); // 12.04
            _locations =_locations.Add(locationTwo); // 2
            _locations = _locations.Add(locationThree); // 3.6

            ImmutableList<ILocateable> locationsInOrder = ImmutableList<ILocateable>.Empty;
            locationsInOrder = locationsInOrder.Add(locationTwo);
            locationsInOrder = locationsInOrder.Add(locationThree);
            locationsInOrder = locationsInOrder.Add(locationOne);
            
            _orderedRoute = new TestPlannable(_startLocation, locationsInOrder);
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

            IPlannable routeToOrder = new TestPlannable(_startLocation, _locations);

            IPlannable route = temp.PlanIPlannable(routeToOrder, _testFactory);

            Assert.AreEqual(route.Locations[2], _orderedRoute.Locations[2]);

        }
    }
}