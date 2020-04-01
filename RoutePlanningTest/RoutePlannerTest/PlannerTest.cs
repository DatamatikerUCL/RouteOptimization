using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner;
using RouteOptimization.RoutePlanner.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanningTest.RoutePlannerTest
{
    [TestClass]
    public class PlannerTest
    {
        [TestInitialize]
        public void PlannerTestSetup()
        {

        }
        [TestMethod]
        public void PlannerCreationTest()
        {
            Planner temp = new Planner();
        }

        [TestMethod]
        public void PlannerImplementsIRouteInputBoundaryTest()
        {
            Planner temp = new Planner();

            Assert.IsInstanceOfType(temp, typeof(IRouteInputBoundary));
        }

        [TestMethod]
        public void GetAvailableLocations()
        {

        }
    }
}
