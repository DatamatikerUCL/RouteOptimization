using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteOptimization.RoutePlanner.Datastructures;

namespace RoutePlannerTest
{
    [TestClass]
    public class AdjacencyMatrixTest
    {
        [TestMethod]
        public void AdjacencyMatrixCreationTest()
        {
            AdjacencyMatrix temp = new AdjacencyMatrix();

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void AdjacencyMatrixSizeTest()
        {
            int size = 5;
            AdjacencyMatrix temp = new AdjacencyMatrix(size);

            Assert.AreEqual(temp.Size, size);
        }

        [TestMethod]
        public void AdjacencyMatrixEmptyDiagonalTest()
        {
            int size = 7;

            AdjacencyMatrix temp = new AdjacencyMatrix(size);

            Assert.AreEqual(temp.GetWeight(0,0), 0.0);
            Assert.AreEqual(temp.GetWeight(3,3), 0.0);
        }

        [TestMethod]
        public void AdjacencyMatrixDefaultWeightTest()
        {
            int size = 2;

            AdjacencyMatrix temp = new AdjacencyMatrix(size);

            Assert.AreEqual(temp.GetWeight(0,1), 1.0);

        }

        [TestMethod]
        public void ChangeWeightTest()
        {
            int size = 6;
            int firstCoordinate = 3;
            int secondCoordinate = 4;
            double newWeight = 5.6;

            AdjacencyMatrix temp = new AdjacencyMatrix(size);
            temp.ChangeWeightAtCoordinates(firstCoordinate, secondCoordinate, newWeight);

            Assert.AreEqual(temp.GetWeight(firstCoordinate, secondCoordinate), newWeight);
        }
    }
}