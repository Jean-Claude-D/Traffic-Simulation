using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLibrary;

namespace TrafficTest
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Car someCar;
            Assert.ThrowsException<ArgumentException>(() => someCar = new Car(null));

            Tile t = new Grass();
            Tile t2 = new Grass();
            Tile t3 = new Grass();
            Tile t4 = new Grass();

            Tile[,] tGrid = new Tile[2, 2];

            tGrid[0, 0] = t;
            tGrid[0, 1] = t2;
            tGrid[1, 0] = t3;
            tGrid[1, 1] = t4;

            Grid someGrid = new Grid(tGrid);
            Car okCar = new Car(5,2,3,someGrid);
            Assert.AreEqual();

        }
    }
}
