using System.Data;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.Graphs;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest.RoutePlanningTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EdgeTest
    {
        private readonly IDistanceCalculator _testCalculator = new TestDistanceCalculator();

        [TestMethod]
        public void CreationTest()
        {
            Edge temp = new Edge();

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void StartPropertyTest()
        {
            ILocateable startLocation = new TestLocation(09135,753.575);
            ILocateable endLocation = new TestLocation(9157.75, 1751.75717);

            Edge temp = new Edge(startLocation, endLocation, _testCalculator.CalculateDistanceBetweenILocateables(startLocation, endLocation));

            Assert.AreEqual(startLocation, temp.Start);
        }

        [TestMethod]
        public void EndPropertyTest()
        {
            ILocateable startLocation = new TestLocation(953.751, 975373.2091);
            ILocateable endLocation = new TestLocation(091573.091757, 095353002.055302246);

            Edge temp = new Edge(startLocation, endLocation, _testCalculator.CalculateDistanceBetweenILocateables(startLocation, endLocation));

            Assert.AreEqual(endLocation, temp.End);
        }
    }
}