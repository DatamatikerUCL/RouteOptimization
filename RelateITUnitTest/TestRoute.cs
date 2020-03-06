using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RelateITUnitTest
{
    [TestClass]
    public class TestRoute
    {
        public string routeName;
        public ImmutableList<ILocateable> locations;
        public Location location1, location2, location3;
        Route route;
        DateTime date;
        double estimatedTime;


        [TestMethod]

        public void TestRouteCreation()
        {
            routeName = "Test Route";
            locations = ImmutableList<ILocateable>.Empty;
            location1 = new Location(123.123, 123.123, "Gaden");
            location2 = new Location(123.123, 123.123, "Gaden 2");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 6.0;
            Route route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.IsNotNull(route);
        }

        [TestMethod]
        public void TestRouteName()
        {
            routeName = "TestedRoute";
            locations = ImmutableList<ILocateable>.Empty;
            location1 = new Location(123.123, 123.123, "Gaden");
            location2 = new Location(123.123, 123.123, "Gaden 2");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 6.0;
            Route route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.AreEqual("TestedRoute", route.Name);
        }
        [TestMethod]
        public void TestRouteListType()
        {
            routeName = "TestedRoute";
            locations = ImmutableList<ILocateable>.Empty;
            location1 = new Location(123.123, 123.123, "Gaden");
            location2 = new Location(123.123, 123.123, "Gaden 2");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 6.0;
            Route route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.IsInstanceOfType(route.Locations, typeof(IImmutableList<ILocateable>));
        }

        [TestMethod]
        public void TestRouteListCount()
        {
            routeName = "TestedRoute";
            locations = ImmutableList<ILocateable>.Empty;
            location1 = new Location(123.123, 123.123, "Gaden");
            location2 = new Location(123.123, 123.123, "Gaden 2");
            location3 = new Location(123.123, 123.123, "Gaden 3");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            locations = locations.Add(location3);
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 6.0;
            Route route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.AreEqual(locations.Count, route.LocationCount);
        }


        [TestMethod]
        public void TestRouteListStartLocation()
        {
            routeName = "TestedRoute";
            locations = ImmutableList<ILocateable>.Empty;
            location1 = new Location(123.123, 123.123, "Gaden");
            location2 = new Location(123.123, 123.123, "Gaden 2");
            location3 = new Location(123.123, 123.123, "Gaden 3");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            locations = locations.Add(location3);
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 6.0;
            Route route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.AreEqual(locations[0], route.StartLocation);
        }

        [TestMethod]
        public void TestRouteDateOfExecution()
        {
            routeName = "TestedRoute";
            locations = ImmutableList<ILocateable>.Empty;
            location1 = new Location(123.123, 123.123, "Gaden");
            location2 = new Location(123.123, 123.123, "Gaden 2");
            location3 = new Location(123.123, 123.123, "Gaden 3");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            locations = locations.Add(location3);
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 6.0;
            Route route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.AreEqual(date, route.DateOfExecution);
        }

        [TestMethod]
        public void TestRouteEstimatedCompletionTime()
        {
            routeName = "TestedRoute";
            locations = ImmutableList<ILocateable>.Empty;
            location1 = new Location(123.123, 123.123, "Gaden");
            location2 = new Location(123.123, 123.123, "Gaden 2");
            location3 = new Location(123.123, 123.123, "Gaden 3");
            locations = locations.Add(location1);
            locations = locations.Add(location2);
            locations = locations.Add(location3);
            date = DateTime.Now;
            date = date.Date;
            estimatedTime = 6.0;
            Route route = new Route(routeName, locations, locations.Count, locations[0], date, estimatedTime);

            Assert.AreEqual(estimatedTime, route.EstimatedCompletionTime);
        }

    }
}
