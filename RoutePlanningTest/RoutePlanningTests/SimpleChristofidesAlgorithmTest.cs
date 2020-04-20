using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms;
using RoutePlannerTest.InterfaceImplementations;
using RoutePlanning.RoutePlanningAlgorithms.SimpleChristofidesAlgorithm;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RoutePlannerTest.RoutePlanningTest
{
    [TestClass]
    public class SimpleChristofidesAlgorithmTest
    {
        private readonly IDistanceCalculator _testCalculator = new TestDistanceCalculator();
        private readonly TestPlannableFactory _testFactory = new TestPlannableFactory();
        private ImmutableList<ILocateable> _locations = ImmutableList<ILocateable>.Empty;
        private ILocateable _startLocation = new TestLocation();

        [TestInitialize]
        public void SetupLocations()
        {
            _startLocation = new TestLocation(0, 0);
            ILocateable locationOne = new TestLocation(1, 12);
            ILocateable locationTwo = new TestLocation(0, 2);
            ILocateable locationThree = new TestLocation(3, 4);
            ILocateable locationFour = new TestLocation(2, 6);
            ILocateable locationFive = new TestLocation(1, 5);
            ILocateable locationSix = new TestLocation(5, 13);

            _locations = _locations.Add(locationOne); // 12.04
            _locations = _locations.Add(locationTwo); // 2
            _locations = _locations.Add(locationThree); // 3.6
            _locations = _locations.Add(locationFour);
            _locations = _locations.Add(locationFive);
            _locations = _locations.Add(locationSix);
        }

        [TestMethod]
        public void ConstructorTakesIDistanceCalculator()
        {
            SimpleChristofides temp = new SimpleChristofides(_testCalculator);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void ImplementsIRoutePlannerInterface()
        {
            SimpleChristofides temp = new SimpleChristofides(_testCalculator);

            Assert.IsInstanceOfType(temp, typeof(IRoutePlanner));
        }

        [TestMethod]
        public void RoutePlannerCorrectEndLocationTest()
        {
            SimpleChristofides temp = new SimpleChristofides(_testCalculator);

            IPlannable routeToOrder = new TestPlannable(_startLocation, _locations);

            IPlannable route = temp.PlanIPlannable(routeToOrder, _testFactory);

            bool optimizedRouteShorterThanUnOrderedRoute = route.TotalLength(_testCalculator) < routeToOrder.TotalLength(_testCalculator);
            Assert.IsTrue(optimizedRouteShorterThanUnOrderedRoute);

        }

        [TestMethod]
        public void ChristofidesBetterThanNearestNeighbour()
        {

            IPlannable routeToOrder = new TestPlannable(_startLocation, _locations);

            SimpleChristofides temp = new SimpleChristofides(_testCalculator);
            IPlannable christofidesRoute = temp.PlanIPlannable(routeToOrder, _testFactory);

            NearestNeighbourRoutePlanner nearestNeighbourRoutePlanner = new NearestNeighbourRoutePlanner(_testCalculator);
            IPlannable nearestNeighbourRoute = nearestNeighbourRoutePlanner.PlanIPlannable(routeToOrder, _testFactory);

            double christofidesRouteLength = christofidesRoute.TotalLength(_testCalculator);
            double nearestNeighbourRouteLength = nearestNeighbourRoute.TotalLength(_testCalculator);


            Assert.AreEqual(christofidesRouteLength, nearestNeighbourRouteLength, 0.001);
        }
    }
}
