using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.Graphs;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest.RoutePlanningTest
{
    [TestClass]
    public class PrimTest
    {
        private ImmutableList<ILocateable> _locations = ImmutableList<ILocateable>.Empty;
        private AdjacencyMatrix _adjacencyMatrix;

        [TestInitialize]
        public void Setup()
        {
            ILocateable locationOne = new TestLocation(1, 3);
            ILocateable locationTwo = new TestLocation(2, 5);
            ILocateable locationThree = new TestLocation(6, 8);
            ILocateable locationFour = new TestLocation(5, 6);

            _locations = _locations.Add(locationOne);
            _locations = _locations.Add(locationTwo);
            _locations = _locations.Add(locationThree);
            _locations = _locations.Add(locationFour);

            _adjacencyMatrix = new AdjacencyMatrix(new TestPlannable(_locations), new TestDistanceCalculator());
        }

        [TestMethod]
        public void PrimMinimumSpanningTreeTest()
        {
            Graph temp = Prim.PrimMinimumSpanningTree(_adjacencyMatrix, _locations.Count, _locations);

            Assert.AreEqual(_locations[0], temp.Edges[0].Start);
        }

        [TestMethod]
        public void SizeTest()
        {
            Graph temp = Prim.PrimMinimumSpanningTree(_adjacencyMatrix, _locations.Count, _locations);

            Assert.AreEqual(3, temp.Weights.Count);
        }

        [TestMethod]
        public void WeightTest()
        {
            Graph temp = Prim.PrimMinimumSpanningTree(_adjacencyMatrix, _locations.Count, _locations);

            Assert.AreEqual(_adjacencyMatrix.Matrix[0][1], temp.Weights[0]);
        }
    }
}