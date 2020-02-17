using System.Collections.Generic;
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

        [TestMethod]
        public void LocationsCountTest()
        {
            Location startLocation = new Location();
            Location locationOne = new Location();
            Location locationTwo = new Location();
            Location locationThree = new Location();
            
            List<Location> locations = new List<Location>
            {
                locationOne, locationTwo, locationThree
            };

            UnorderedRoute tempRoute = new UnorderedRoute(startLocation, locations);

            Assert.AreEqual(tempRoute.LocationsCount, 4);
        }
    }
}
