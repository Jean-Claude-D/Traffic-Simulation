using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLibrary;

namespace TrafficTest
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void TestConstructorAndProperties()
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

            //Check constructor without x and y
            Grid someGrid = new Grid(tGrid);
            Car okCar = new Car(someGrid);

            Assert.AreEqual(okCar.EmissionMoving, 5);
            Assert.AreEqual(okCar.EmissionIdle,2);
            Assert.AreEqual(okCar.Passengers, 3);

            //check constructor with x and y
            Car newCar = new Car(someGrid,10,12);

            Assert.AreEqual(newCar.EmissionMoving, 5);
            Assert.AreEqual(newCar.EmissionIdle, 2);
            Assert.AreEqual(newCar.Passengers, 3);

            Assert.AreEqual(newCar.X,10);
            Assert.AreEqual(newCar.Y, 12);
        }
        public void TestInIntersection()
        {
            IntersectionTile t = new IntersectionTile();
            IntersectionTile t2 = new IntersectionTile();
            IntersectionTile t3 = new IntersectionTile();
            IntersectionTile t4 = new IntersectionTile();

            Tile[,] iGrid = new Tile[2, 2];
            iGrid[0, 0] = t;
            iGrid[0, 1] = t2;
            iGrid[1, 0] = t3;
            iGrid[1, 1] = t4;

            Car newCar = new Car(iGrid, 1, 1);

            Assert.AreEqual();
        }
    }
}
