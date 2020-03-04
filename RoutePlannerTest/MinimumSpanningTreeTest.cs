using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm;

namespace RoutePlannerTest
{
    [TestClass]
    public class MinimumSpanningTreeTest
    {
        [TestMethod]
        public void CreationTest()
        {
            MinimumSpanningTree temp = new MinimumSpanningTree();

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void WeightsPropertyTest()
        {
            MinimumSpanningTree temp = new MinimumSpanningTree();

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
            MinimumSpanningTree temp = new MinimumSpanningTree();

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
    }
}