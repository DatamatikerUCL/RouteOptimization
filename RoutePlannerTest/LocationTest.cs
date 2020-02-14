using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RoutePlannerTest
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void CreationTest()
        {
            Location tempLocation = new Location();
            Assert.IsNotNull(tempLocation);
        }

        [TestMethod]
        public void AddressPropertyTest()
        {
            string addressString = "TestAddress 40, 2457 Testington";
            Location tempLocation = new Location(addressString);

            Assert.AreEqual(tempLocation.Address, addressString);
        }

        [TestMethod]
        public void LatitudePropertyTest()
        {
            double latitude = 209135.573190;
            Location tempLocation = new Location("rcgoaeduh", latitude);

            Assert.AreEqual(tempLocation.Latitude, latitude, 0.1);
        }

        [TestMethod]
        public void LongtitudePropertyTest()
        {
            double longtitude = 75319642091357.7531902;
            Location tempLocation = new Location("%735110246HDIU", 7531902.75319, longtitude);

            Assert.AreEqual(tempLocation.Longtitude, longtitude, 0.01);
        }

    }
}
