using System;
using System.Collections.Immutable;
using RelateIT.Models;
using RouteOptimization.RoutePlanner.Datastructures;
using RouteOptimization.RoutePlanner.Interfaces;
using Xunit;

namespace XUnitTestingLibrary
{
    public class RelateITTest
    {

        string routeName = "TestRoute";
        ImmutableList<ILocateable> locations;
        private Location location1, location2;


        [Fact]
        public void TestLocationCreation()
        {
           location1 = new Location(55.499680, 10.096780);
           location2 = new Location(55.499700, 10.096800);

            Assert.NotNull(location1);
            Assert.IsType<Location>(location1);
        }



        [Fact]
        public void TestRouteCreation()
        {
            locations.Add(location1);
            locations.Add(location2);

            RoutePlanned route = new RoutePlanned(routeName, locations, locations.Count, locations[0]);


        }
    }
}
