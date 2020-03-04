using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.RoutePlanningAlgorithms.ChristofidesAlgorithm;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class PrimTest
    {
        private ImmutableList<ILocateable> _locations = ImmutableList<ILocateable>.Empty;
        private AdjacencyList _adjacencyList;

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

            _adjacencyList = new AdjacencyList(new TestPlannable(_locations), new TestDistanceCalculator());
        }

        [TestMethod]
        public void PrimMinimumSpanningTreeTest()
        {
            MinimumSpanningTree temp = Prim.PrimMinimumSpanningTree(_adjacencyList, _locations.Count, _locations);
        }
    }
}