using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;
using RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class ChristofidesAlgorithmRoutePlannerTest
    {
        private readonly IDistanceCalculator _calculator = new TestDistanceCalculator();

        [TestMethod]
        public void InheritanceTest()
        {
            IRoutePlanner tempPlanner = new ChristofidesAlgorithmRoutePlanner(_calculator);

            Assert.IsInstanceOfType(tempPlanner, typeof(IRoutePlanner));
        }

    }
}