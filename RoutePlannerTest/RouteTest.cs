using System.Collections.Generic;
using System.Collections.Immutable;
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
        public void LocationsCountTest()
        {
            Location startLocation = new Location();
            Location locationOne = new Location();
            Location locationTwo = new Location();
            Location locationThree = new Location();
            
            ImmutableList<Location> locations = ImmutableList<Location>.Empty;
            locations = locations.Add(locationOne);
            locations = locations.Add(locationTwo);
            locations = locations.Add(locationThree);

            UnorderedRoute tempRoute = new UnorderedRoute(startLocation, locations);

            Assert.AreEqual(4, tempRoute.LocationsCount);
        }
    }
}
