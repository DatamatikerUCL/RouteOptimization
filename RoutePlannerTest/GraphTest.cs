using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;
using RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class MinimumSpanningTreeTest
    {
        IDistanceCalculator _testDistanceCalculator = new TestDistanceCalculator();
        [TestMethod]
        public void CreationTest()
        {
            Graph temp = new Graph();

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void WeightsPropertyTest()
        {
            Graph temp = new Graph();

            List<double> doubles = new List<double>();

            doubles.Add(531.537);
            doubles.Add(69.69143);
            doubles.Add(5757.16575);
            temp.Weights = doubles;

            Assert.AreEqual(temp.Weights[2], doubles[2]);

        }

        [TestMethod]
        public void EdgesPropertyTest()
        {
            Graph temp = new Graph();

            List<Edge> edges = new List<Edge>();
            Edge edgeOne = new Edge();
            Edge edgeTwo = new Edge();
            Edge edgeThree = new Edge();

            edges.Add(edgeOne);
            edges.Add(edgeTwo);
            edges.Add(edgeThree);

            temp.Edges = edges;

            Assert.AreEqual(edgeOne, temp.Edges[0]);
        }

        [TestMethod]
        public void OddDegreesTest()
        {
            ILocateable locationOne = new TestLocation();
            ILocateable locationTwo = new TestLocation();
            ILocateable locationThree = new TestLocation();
            ILocateable locationFour = new TestLocation();
            ILocateable locationFive = new TestLocation();

            Graph temp = new Graph();

            List<Edge> edges = new List<Edge>();
            Edge edgeOne = new Edge(locationOne, locationTwo);
            Edge edgeTwo = new Edge(locationOne, locationThree);
            Edge edgeThree = new Edge(locationFive, locationThree);
            Edge edgeFour = new Edge(locationFive, locationFour);
            
            edges.Add(edgeOne);
            edges.Add(edgeTwo);
            edges.Add(edgeThree);
            edges.Add(edgeFour);

            temp.Edges = edges;
            
            List<ILocateable> locationsWithOddDegrees = temp.GetVertexesWithOddDegrees();

            Assert.AreEqual(locationTwo, locationsWithOddDegrees[0]);
        }

        [TestMethod]
        public void HandShakeLemmaTest()
        {
            ILocateable locationOne = new TestLocation();
            ILocateable locationTwo = new TestLocation();
            ILocateable locationThree = new TestLocation();
            ILocateable locationFour = new TestLocation();
            ILocateable locationFive = new TestLocation();

            Graph temp = new Graph();

            List<Edge> edges = new List<Edge>()
            {
                new Edge(locationOne, locationThree),
                new Edge(locationTwo, locationThree),
                new Edge(locationThree, locationFour),
                new Edge(locationFour, locationFive)
            };

            temp.Edges = edges;

            List<ILocateable> edgesWithOddDegrees = temp.GetVertexesWithOddDegrees();

            Assert.AreEqual(0, edgesWithOddDegrees.Count % 2);
        }

        [TestMethod]
        public void PerfectMatchingWithMinimumWeightTest()
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
            
            Graph newGraph = temp.ToGraph();

            newGraph = newGraph.ToMinimumWeightPerfectMatching();

            Assert.AreEqual(2, newGraph.Edges.Count);
        }

        [TestMethod]
        public void PerfectMatchingWithMinimumWeightTest2()
        {
            ILocateable locationOne = new TestLocation(1, 37);
            ILocateable locationTwo = new TestLocation(4, 57);
            ILocateable locationThree = new TestLocation(675, 637);
            ILocateable locationFour = new TestLocation(75, 63);
            ILocateable locationFive = new TestLocation(74,67);
            ILocateable locationSix = new TestLocation(3, 67);

            ImmutableList<ILocateable> locations = ImmutableList<ILocateable>.Empty;
            locations = locations.Add(locationOne);
            locations = locations.Add(locationTwo);
            locations = locations.Add(locationThree);
            locations = locations.Add(locationFour);
            locations = locations.Add(locationFive);
            locations = locations.Add(locationSix);

            AdjacencyMatrix temp = new AdjacencyMatrix(locations, _testDistanceCalculator);
            
            Graph newGraph = temp.ToGraph();

            newGraph = newGraph.ToMinimumWeightPerfectMatching();

            Assert.AreEqual(3, newGraph.Edges.Count);

        }

    }
}