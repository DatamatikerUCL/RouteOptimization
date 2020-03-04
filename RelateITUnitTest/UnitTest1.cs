using System;
using RelateIT.Droid;
using RelateIT.Models;
using System.Collections.Immutable;
using RouteOptimization.RoutePlanner.Datastructures;
using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RelateITUnitTest
{
    [TestClass]
    public class RelateITTests
    {
        public string routeName;
        public ImmutableList<ILocateable> locations;
        public Location location1, location2;
        RoutePlanned route;

        [TestMethod]
        public void TestLocationCreation()
        {
            location1 = new Location(55.499680, 10.096780);
            location2 = new Location(55.499700, 10.096800);

            Assert.IsNotNull(location1);
        }

        [TestMethod]
        public void TestLocationInterface()
        {
            location1 = new Location(55.499680, 10.096780);
            Assert.IsInstanceOfType(location1, typeof(ILocateable));
        }




        [TestMethod]
        public void TestRouteCreation()
        {
            locations = ImmutableList<ILocateable>.Empty;
            routeName = "TestRoute";
            location1 = new Location(55.499680, 10.096780);
            location2 = new Location(55.499700, 10.096800);
            locations.Add(location1);
            locations.Add(location2);
            route = new RoutePlanned(routeName, locations, locations.Count, locations[0]);

            Assert.IsNotNull(route);

        }
    }
}
