using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLibrary;

namespace TrafficTest
{
    [TestClass]
    public class VehicleTest
    {
        /// <summary>
        /// Testing car constructor and constructor of all of car's children, NextInIntersection function for all vehicles, and IsIntersection property
        /// </summary>
        [TestMethod]
        public void TestConstructorAndProperties()
        {

            Tile[,] tGrid = new Tile[4, 4];
            for (int i = 0; i < tGrid.GetLength(0); i++)
            {
                for (int j = 0; j < tGrid.GetLength(1); j++)
                {
                    tGrid[i, j] = new Grass();
                }
            }
            Grid someGrid = new Grid(tGrid);

            Car okCar = new Car(someGrid,2,3);

            Assert.AreEqual(okCar.EmissionMoving, 5);
            Assert.AreEqual(okCar.EmissionIdle, 2);
            Assert.AreEqual(okCar.Passengers, 3);


            Assert.AreEqual(okCar.X, 2);
            Assert.AreEqual(okCar.Y, 3);
        }
        [TestMethod]

        public void TestInIntersection()
        {
            Tile[,] tGrid = new Tile[4, 4];
            for (int i = 0; i < tGrid.GetLength(0); i++)
            {
                for (int j = 0; j < tGrid.GetLength(1); j++)
                {
                    if (i == 1 && j == 2)
                        tGrid[i, j] = new IntersectionTile();
                    else
                        tGrid[i, j] = new Grass();
                }
            }
            Grid someGrid = new Grid(tGrid);

            Car newCar = new Car(someGrid, 1, 2);
            Car notIn = new Car(someGrid, 0, 0);

            Assert.AreEqual(newCar.InIntersection(), true);
            Assert.AreEqual(notIn.InIntersection(), false);
        }
        [TestMethod]
        public void TestNextInIntersection()
        {
            Tile[,] tGrid = new Tile[4, 4];
            for (int i = 0; i < tGrid.GetLength(0); i++)
            {
                for (int j = 0; j < tGrid.GetLength(1); j++)
                {
                    if (i == 3 && j == 1)
                        tGrid[i, j] = new Road(Direction.Left);
                    else if (i == 2 && j == 2)
                        tGrid[i, j] = new IntersectionTile();
                    else if (i == 3 && j == 2)
                        tGrid[i, j] = new Road(Direction.Left);
                    else
                    {
                        tGrid[i, j] = new Grass();
                    }
                }
            }
            Grid someGrid = new Grid(tGrid);

            Car notCar = new Car(someGrid, 3, 2);
            Car otherCar = new Car(someGrid, 3, 1);
            Assert.AreEqual(notCar.NextIsIntersection(), true);

        }
        [TestMethod]
        public void TestMove()
        {
            ISignalStrategy someS = new FixedSignal(20, 5, 10, 5);
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

            Car downCar = new Car(board, 1, 0);
            downCar.Direction = Direction.Down;
            Car leftCar = new Car(board, 2, 2);
            leftCar.Direction = Direction.Left;

            downCar.Move(someS);
            leftCar.Move(someS);

            //Check that the cars move either down or left
            Assert.AreEqual(downCar.X, 1);
            Assert.AreEqual(leftCar.X, 1);

            //Check that the tiles are occupied where the car moved
            Assert.AreEqual(true, board[downCar.X,downCar.Y].Occupied);
            Assert.AreEqual(true, board[leftCar.X,leftCar.Y].Occupied);

            //Check that the tiles that were previously occupied are no longer occupied
            Assert.AreEqual(true, board[downCar.X, downCar.Y + 1].Occupied);
            Assert.AreEqual(true, board[leftCar.X + 1, leftCar.Y].Occupied);

        }
        [TestMethod]
        public void TestMotorcycle()
        {
            Motorcycle m1;
            Assert.ThrowsException<ArgumentException>(() => m1 = new Motorcycle(null));

            Tile[,] tGrid = new Tile[4, 4];
            for (int i = 0; i < tGrid.GetLength(0); i++)
            {
                for (int j = 0; j < tGrid.GetLength(1); j++)
                {
                    tGrid[i, j] = new Grass();
                }
            }
            Grid someGrid = new Grid(tGrid);

            Motorcycle m = new Motorcycle(someGrid);

            Assert.AreEqual(m.EmissionMoving, 2);
            Assert.AreEqual(m.EmissionIdle, 1);
            Assert.AreEqual(m.Passengers, 1);
        }
        [TestMethod]
        public void TestElectric()
        {
            
            Electric e1;
            Assert.ThrowsException<ArgumentException>(() => e1 = new Electric(null));

            Tile[,] tGrid = new Tile[4, 4];
            for (int i = 0; i < tGrid.GetLength(0); i++)
            {
                for (int j = 0; j < tGrid.GetLength(1); j++)
                {
                    tGrid[i, j] = new Grass();
                }
            }
            Grid someGrid = new Grid(tGrid);

            //Check constructor without x and y
            Car okCar = new Car(someGrid);
            Electric e = new Electric(okCar); 


            Assert.AreEqual(e.EmissionMoving, okCar.EmissionMoving / 4);
            Assert.AreEqual(e.EmissionIdle, 0);
            Assert.AreEqual(e.Passengers, okCar.Passengers);
        }
    }
}
