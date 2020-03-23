using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm;
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

        [TestMethod]
        public void CorrectEndlocationTest()
        {

        }
    }
}