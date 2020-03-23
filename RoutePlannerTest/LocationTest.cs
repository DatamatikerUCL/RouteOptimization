using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanning.Datastructures;
using RoutePlannerTest.InterfaceImplementations;

namespace RoutePlannerTest
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void CreationTest()
        {
            ILocateable tempLocation = new TestLocation();
            Assert.IsNotNull(tempLocation);
        }

        [TestMethod]
        public void InterfaceImplentationTest()
        {
            ILocateable tempLocation = new TestLocation();
            Assert.IsInstanceOfType(tempLocation, typeof(ILocateable));
        }

        [TestMethod]
        public void LatitudePropertyTest()
        {
            double latitude = 209135.573190;
            ILocateable tempLocation = new TestLocation(latitude);

            Assert.AreEqual(tempLocation.Latitude, latitude, 0.1);
        }

        [TestMethod]
        public void LongtitudePropertyTest()
        {
            double longtitude = 75319642091357.7531902;
            ILocateable tempLocation = new TestLocation(64209024.420, longtitude);

            Assert.AreEqual(tempLocation.Longtitude, longtitude, 0.01);
        }

    }
}
