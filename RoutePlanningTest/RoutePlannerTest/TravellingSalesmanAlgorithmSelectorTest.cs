using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms;
using RoutePlanner;
using RoutePlannerTest.InterfaceImplementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanningTest.RoutePlannerTest
{
    [TestClass]
    public class TravellingSalesmanAlgorithmSelectorTest
    {

        [TestMethod]
        public void ConstructorTakesIDistanceCalculatorTest()
        {
            IDistanceCalculator distanceCalculator = new TestDistanceCalculator();

            TravellingSalesmanAlgorithmSelector temp = new TravellingSalesmanAlgorithmSelector(distanceCalculator);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void GetOptimalAlgorithmReturnTypeIRoutePlanner()
        {
            IDistanceCalculator distanceCalculator = new TestDistanceCalculator();
            TravellingSalesmanAlgorithmSelector temp = new TravellingSalesmanAlgorithmSelector(distanceCalculator);

            IRoutePlanner tempPlanner = temp.GetOptimalAlgorithm();

            Assert.IsInstanceOfType(tempPlanner, typeof(IRoutePlanner));
        }

        [TestMethod]
        public void DefaultAlgorithmIsNearestNeighbour()
        {
            IDistanceCalculator distanceCalculator = new TestDistanceCalculator();
            TravellingSalesmanAlgorithmSelector temp = new TravellingSalesmanAlgorithmSelector(distanceCalculator);

            IRoutePlanner tempPlanner = temp.GetOptimalAlgorithm();

            Assert.IsInstanceOfType(tempPlanner, typeof(NearestNeighbourRoutePlanner));
        }
    }
}
