using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning;
using RouteOptimization.RoutePlanning.Datastructures;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest.RoutePlanningTest
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void InterfaceImplementationTest()
        {
            IPlannable tempRoute = new TestPlannable();

            Assert.IsInstanceOfType(tempRoute, typeof(IPlannable));

        }


        [TestMethod]
        public void LocationsCountTest()
        {
            ILocateable startLocation = new TestLocation();
            ILocateable locationOne = new TestLocation();
            ILocateable locationTwo = new TestLocation();
            ILocateable locationThree = new TestLocation();
            
            ImmutableList<ILocateable> locations = ImmutableList<ILocateable>.Empty;
            locations = locations.Add(locationOne);
            locations = locations.Add(locationTwo);
            locations = locations.Add(locationThree);

            IPlannable tempRoute = new TestPlannable(startLocation, locations);

            Assert.AreEqual(4, tempRoute.LocationCount);
        }
    }
}
