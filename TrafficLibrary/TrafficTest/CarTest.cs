using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLibrary;

namespace TrafficTest
{
    [TestClass]
    public class CarTest
    {
        /// <summary>
        /// Testing car constructor, NextInIntersection function for all vehicles, and IsIntersection property
        /// </summary>
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
        [TestMethod]

        public void TestInIntersection()
        {
            Grass t = new Grass();
            IntersectionTile t2 = new IntersectionTile();
            IntersectionTile t3 = new IntersectionTile();
            IntersectionTile t4 = new IntersectionTile();

            Tile[,] iGrid = new Tile[2, 2];
            iGrid[0, 0] = t;
            iGrid[0, 1] = t2;
            iGrid[1, 0] = t3;
            iGrid[1, 1] = t4;

            Grid someGrid = new Grid(iGrid);

            Car newCar = new Car(someGrid, 1, 1);
            Car notIn = new Car(someGrid, 0, 0);

            Assert.AreEqual(newCar.InIntersection(),true);
            Assert.AreEqual(notIn.InIntersection(),false);
        }
        [TestMethod]
        public void TestNextInIntersection()
        {
            Road t = new Road(Direction.Left);
            Grass t2 = new Grass();
            IntersectionTile t3 = new IntersectionTile();
            Road t4 = new Road(Direction.Left);

            Tile[,] iGrid = new Tile[2, 2];
            iGrid[0, 0] = t2;
            iGrid[0, 1] = t;
            iGrid[1, 0] = t3;
            iGrid[1, 1] = t4;

            Grid someGrid = new Grid(iGrid);

            Car newCar = new Car(someGrid, 0, 1);
            Car someCar = new Car(someGrid, 1, 1);
            Assert.AreEqual(newCar.NextIsIntersection(),false);
            Assert.AreEqual(someCar.NextIsIntersection(), true); 
        }

        public void TestMove()
        {

        }
    }
}
