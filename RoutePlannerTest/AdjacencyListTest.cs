using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;
using RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class AdjacencyListTest
    {
        private IPlannable testRoute;
        private IDistanceCalculator testDistanceCalculator = new TestDistanceCalculator();

        [TestInitialize]
        public void LocationsSetup()
        {
            TestLocation locationOne = new TestLocation(12, 15);
            TestLocation locationTwo = new TestLocation(1, 91);
            TestLocation locationThree = new TestLocation(7, 13);

            ImmutableList<ILocateable> tempList = ImmutableList<ILocateable>.Empty;
            tempList = tempList.Add(locationOne);
            tempList = tempList.Add(locationTwo);
            tempList= tempList.Add(locationThree);

            testRoute = new TestPlannable(tempList);
        }
        [TestMethod]
        public void CreationTest()
        {
            AdjacencyList temp = new AdjacencyList(new TestPlannable(), testDistanceCalculator);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void SquareTest()
        {
            
            AdjacencyList temp = new AdjacencyList(testRoute, testDistanceCalculator);

            Assert.AreEqual(temp.Matrix.Count, temp.Matrix[0].Count);
        }

        [TestMethod]
        public void WeightTest1()
        {
            AdjacencyList temp = new AdjacencyList(testRoute, testDistanceCalculator);

            Assert.AreEqual(
                temp.Matrix[1][0],
                testDistanceCalculator.CalculateDistanceBetweenLocations(
                    testRoute.Locations[1],
                    testRoute.Locations[0]));
        }

        [TestMethod]
        public void WeightTestZeroDiagonal()
        {
            AdjacencyList temp = new AdjacencyList(testRoute, testDistanceCalculator);

            Assert.AreEqual(0, temp.Matrix[1][1]);
        }
    }
    
}