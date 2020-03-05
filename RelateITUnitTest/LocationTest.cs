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
        Route route;
        DateTime date;
        double estimatedTime;

        [TestMethod]
        public void TestLocationCreation()
        {
            location1 = new Location(55.499680, 10.096780, "Street 3");
            location2 = new Location(55.499700, 10.096800, "Street 4");

            Assert.IsNotNull(location1);
        }

        [TestMethod]
        public void TestLocationInterface()
        {
            location1 = new Location(55.499680, 10.096780, "Hansensgade 4");
            Assert.IsInstanceOfType(location1, typeof(ILocateable));
        }




        [TestMethod]
        public void TestRouteCreation()
        {
            locations = ImmutableList<ILocateable>.Empty;
            routeName = "TestRoute";
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 10.0;
            location1 = new Location(55.499680, 10.096780, "Baren 2");
            location2 = new Location(55.499700, 10.096800, "Gaden 2");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.IsNotNull(route);
        }


        [TestMethod]
        public void TestLocationAdress()
        {
            string adress = "Schacksgade 2, 5000, Odense C";
            Location testLocation = new Location(12345.1231, 123123.123123, adress);
            Assert.AreEqual("Schacksgade 2, 5000, Odense C", testLocation.Adress);
        }


    }
}
