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
            //Instantiating 16 tiles for the grid
            Grass g1 = new Grass();
            Grass g2 = new Grass();
            Grass g3 = new Grass();
            Grass g4 = new Grass();
            Grass g5 = new Grass();
            Grass g6 = new Grass();
            Grass g7 = new Grass();
            Grass g8 = new Grass();
            Grass g9 = new Grass();
            IntersectionTile i = new IntersectionTile();
            Road rL1 = new Road(Direction.Left);
            Road rL2 = new Road(Direction.Left);
            Road rL3 = new Road(Direction.Left);
            Road rD1 = new Road(Direction.Down);
            Road rD2 = new Road(Direction.Down);
            Road rD3 = new Road(Direction.Down);

            Tile[,] sim = new Tile[4, 4];

            sim[0, 0] = g1;
            sim[0, 1] = rD1;
            sim[0, 2] = g2;
            sim[0, 3] = g3;
            sim[1, 0] = g4;
            sim[1, 1] = rD2;
            sim[1, 2] = g5;
            sim[1, 3] = g6;
            sim[2, 0] = rL1;
            sim[2, 1] = i;
            sim[2, 2] = rL2;
            sim[2, 3] = rL3;
            sim[3, 0] = g7;
            sim[3, 1] = rD3;
            sim[3, 2] = g8;
            sim[3, 3] = g9;

            Grid board = new Grid(sim);

            Car noMove = new Car(board,3,3);
            Car downCar = new Car(board, 1, 0);
            Car leftCar = new Car(board,2,2);

            noMove.Move();

        }
    }
}
