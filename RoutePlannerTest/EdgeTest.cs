using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class EdgeTest
    {
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

            Edge temp = new Edge(startLocation, endLocation);

            Assert.AreEqual(startLocation, temp.Start);
        }

        [TestMethod]
        public void EndPropertyTest()
        {
            ILocateable startLocation = new TestLocation(953.751, 975373.2091);
            ILocateable endLocation = new TestLocation(091573.091757, 095353002.055302246);

            Edge temp = new Edge(startLocation, endLocation);

            Assert.AreEqual(endLocation, temp.End);
        }
    }
}