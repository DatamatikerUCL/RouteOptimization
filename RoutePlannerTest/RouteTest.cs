using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RoutePlannerTest
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void OrderedRouteInheritanceTest()
        {
            OrderedRoute tempRoute = new OrderedRoute();

            Assert.IsInstanceOfType(tempRoute, typeof(Route));

        }

        [TestMethod]
        public void UnorderedRouteInheritanceTest()
        {
            UnorderedRoute tempRoute = new UnorderedRoute();

            Assert.IsInstanceOfType(tempRoute, typeof(Route));
        }

        [TestMethod]
        public void OrderedRouteEndlocationPropertyTest()
        {
            OrderedRoute tempRoute = new OrderedRoute();
            tempRoute.EndLocation = new Location();

            Assert.IsNotNull(tempRoute.EndLocation);
        }
    }
}
