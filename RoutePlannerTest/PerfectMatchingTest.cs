using System.Collections.Immutable;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class PerfectMatchingTest
    {
        private TestDistanceCalculator _testDistanceCalculator = new TestDistanceCalculator();

        [TestMethod]
        public void BlossomMethodReturnGraphTest()
        {
            object tempObject = PerfectMatching.BlossomLeastWeight(new Graph());

            Assert.IsInstanceOfType(tempObject, typeof(Graph));
        }

        [TestMethod]
        public void BlossomSizeTest()
        {
            ILocateable locationOne = new TestLocation(753, 754);
            ILocateable locationTwo = new TestLocation(7, 3);
            ILocateable locationThree = new TestLocation(6, 6);
            ILocateable locationFour = new TestLocation(6, 7);

            ImmutableList<ILocateable> tempLocations = ImmutableList<ILocateable>.Empty;
            tempLocations = tempLocations.Add(locationOne);
            tempLocations = tempLocations.Add(locationTwo);
            tempLocations = tempLocations.Add(locationThree);
            tempLocations = tempLocations.Add(locationFour);

            AdjacencyMatrix tempMatrix = new AdjacencyMatrix(tempLocations, _testDistanceCalculator);

            Graph tempGraph = tempMatrix.ToGraph();

            Graph matching = PerfectMatching.BlossomLeastWeight(tempGraph);

            Assert.AreEqual(2, matching.Edges.Count);
        }

        [TestMethod]
        public void BlossomLeastWeightTest()
        {
            ILocateable locationOne = new TestLocation(753, 754);
            ILocateable locationTwo = new TestLocation(7, 3);
            ILocateable locationThree = new TestLocation(6, 6);
            ILocateable locationFour = new TestLocation(6, 7);

            ImmutableList<ILocateable> tempLocations = ImmutableList<ILocateable>.Empty;
            tempLocations = tempLocations.Add(locationOne);
            tempLocations = tempLocations.Add(locationTwo);
            tempLocations = tempLocations.Add(locationThree);
            tempLocations = tempLocations.Add(locationFour);

            AdjacencyMatrix tempMatrix = new AdjacencyMatrix(tempLocations, _testDistanceCalculator);

            Graph tempGraph = tempMatrix.ToGraph();

            Graph matching = PerfectMatching.BlossomLeastWeight(tempGraph);

            Assert.IsTrue(tempGraph.Weights.Sum(item => item) > matching.Weights.Sum(w => w));
        }
    }
}