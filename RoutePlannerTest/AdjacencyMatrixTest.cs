using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;
using RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class AdjacencyMatrixTest
    {
        private IPlannable _testRoute;
        private IDistanceCalculator _testDistanceCalculator = new TestDistanceCalculator();

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

            _testRoute = new TestPlannable(tempList);
        }
        
        [TestMethod]
        public void CreationTest()
        {
            AdjacencyMatrix temp = new AdjacencyMatrix(new TestPlannable(), _testDistanceCalculator);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void OverloadedConstructorTest()
        {
            AdjacencyMatrix temp = new AdjacencyMatrix(ImmutableList<ILocateable>.Empty, _testDistanceCalculator);

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void SquareTest()
        {
            
            AdjacencyMatrix temp = new AdjacencyMatrix(_testRoute, _testDistanceCalculator);

            Assert.AreEqual(temp.Matrix.Count, temp.Matrix[0].Count);
        }

        [TestMethod]
        public void WeightTest1()
        {
            AdjacencyMatrix temp = new AdjacencyMatrix(_testRoute, _testDistanceCalculator);

            Assert.AreEqual(
                temp.Matrix[1][0],
                _testDistanceCalculator.CalculateDistanceBetweenLocations(
                    _testRoute.Locations[1],
                    _testRoute.Locations[0]));
        }

        [TestMethod]
        public void WeightTestZeroDiagonal()
        {
            AdjacencyMatrix temp = new AdjacencyMatrix(_testRoute, _testDistanceCalculator);

            Assert.AreEqual(0, temp.Matrix[1][1]);
        }

        [TestMethod]
        public void PerfectMinimumMatching()
        {
            ILocateable locationOne = new TestLocation(1, 37);
            ILocateable locationTwo = new TestLocation(4, 57);
            ILocateable locationThree = new TestLocation(675, 637);
            ILocateable locationFour = new TestLocation(75, 63);

            ImmutableList<ILocateable> locations = ImmutableList<ILocateable>.Empty;
            locations = locations.Add(locationOne);
            locations = locations.Add(locationTwo);
            locations = locations.Add(locationThree);
            locations = locations.Add(locationFour);

            AdjacencyMatrix temp = new AdjacencyMatrix(locations, _testDistanceCalculator);
            
            Graph perfectMinimumMatching = temp.GetMinimumWeightPerfectMatching();

            Assert.AreEqual(2, perfectMinimumMatching.Edges.Count);

        }
    }
    
}