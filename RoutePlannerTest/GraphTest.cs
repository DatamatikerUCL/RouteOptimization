using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class MinimumSpanningTreeTest
    {
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

    }
}