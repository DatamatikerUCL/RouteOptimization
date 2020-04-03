using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RouteOptimization.RoutePlanning.Interfaces;
using RouteOptimization.RoutePlanning.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest.RoutePlanningTest
{
    [TestClass]
    public class GraphTest
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
        public void CombineGraphEdgesTest()
        {
            ILocateable locationOne = new TestLocation(732, 327);
            ILocateable locationTwo = new TestLocation(75, 3);
            ILocateable locationThree = new TestLocation(47, 75);
            ILocateable locationFour = new TestLocation(6, 1);
            ILocateable locationFive = new TestLocation(7, 8);
            ILocateable locationSix = new TestLocation(9, 5);

            ImmutableList<ILocateable> locationListOne = ImmutableList<ILocateable>.Empty;
            locationListOne = locationListOne.Add(locationOne);
            locationListOne = locationListOne.Add(locationTwo);
            locationListOne = locationListOne.Add(locationThree);
            locationListOne = locationListOne.Add(locationFour);

            ImmutableList<ILocateable> locationListTwo = ImmutableList<ILocateable>.Empty;
            locationListTwo = locationListTwo.Add(locationFive);
            locationListTwo = locationListTwo.Add(locationSix);

            AdjacencyMatrix tempOne = new AdjacencyMatrix(locationListOne, _testDistanceCalculator);
            AdjacencyMatrix tempTwo = new AdjacencyMatrix(locationListTwo, _testDistanceCalculator);
            Graph graphOne = tempOne.ToGraph();
            Graph graphTwo = tempTwo.ToGraph();
            
            Graph combinedGraph = graphOne.CombineGraph(graphTwo);

            Assert.AreEqual(graphOne.Edges.Count + graphTwo.Edges.Count, combinedGraph.Edges.Count);
        }

        [TestMethod]
        public void CombineGraphWeightsTest()
        {
            ILocateable locationOne = new TestLocation(732, 327);
            ILocateable locationTwo = new TestLocation(75, 3);
            ILocateable locationThree = new TestLocation(47, 75);
            ILocateable locationFour = new TestLocation(6, 1);
            ILocateable locationFive = new TestLocation(7, 8);
            ILocateable locationSix = new TestLocation(9, 5);

            ImmutableList<ILocateable> locationListOne = ImmutableList<ILocateable>.Empty;
            locationListOne = locationListOne.Add(locationOne);
            locationListOne = locationListOne.Add(locationTwo);
            locationListOne = locationListOne.Add(locationThree);
            locationListOne = locationListOne.Add(locationFour);

            ImmutableList<ILocateable> locationListTwo = ImmutableList<ILocateable>.Empty;
            locationListTwo = locationListTwo.Add(locationFive);
            locationListTwo = locationListTwo.Add(locationSix);

            AdjacencyMatrix tempOne = new AdjacencyMatrix(locationListOne, _testDistanceCalculator);
            AdjacencyMatrix tempTwo = new AdjacencyMatrix(locationListTwo, _testDistanceCalculator);
            Graph graphOne = tempOne.ToGraph();
            Graph graphTwo = tempTwo.ToGraph();
            
            Graph combinedGraph = graphOne.CombineGraph(graphTwo);

            Assert.AreEqual(graphOne.Weights.Count + graphTwo.Weights.Count, combinedGraph.Weights.Count);
        }

    }
}