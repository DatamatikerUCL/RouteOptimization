using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanningTest.RoutePlannerTest
{
    [TestClass]
    public class PlannerTest
    {
        [TestMethod]
        public void PlannerCreationTest()
        {
            Planner temp = new Planner();
        }
    }
}
