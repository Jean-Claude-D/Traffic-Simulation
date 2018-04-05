using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLibrary;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TrafficTest
{
    [TestClass]
    public class IntersectionTest
    {
        [TestMethod]
        public void TestIntersection()
        {
            //make the grid
            Tile[,] tiles = new Tile[4, 4];
            tiles[0, 0] = new Grass();
            tiles[1, 0] = new Road(Direction.Down);
            tiles[2, 0] = new Road(Direction.Up);
            tiles[3, 0] = new Grass();
            tiles[0, 1] = new Road(Direction.Left);
            tiles[1, 1] = new IntersectionTile();
            tiles[2, 1] = new IntersectionTile();
            tiles[3, 1] = new Road(Direction.Left);
            tiles[0, 2] = new Road(Direction.Right);
            tiles[1, 2] = new IntersectionTile();
            tiles[2, 2] = new IntersectionTile();
            tiles[3, 2] = new Road(Direction.Right);
            tiles[0, 3] = new Grass();
            tiles[1, 3] = new Road(Direction.Down);
            tiles[2, 3] = new Road(Direction.Up);
            tiles[3, 3] = new Grass();
            Grid grid = new Grid(tiles);
            //make the intersection, which tests intersection's constructor
            FixedSignal strategy = new FixedSignal(20, 5, 10, 5);
            List<Vector2> startCoords = new List<Vector2>();
            startCoords.Add(new Vector2(0, 2));
            Intersection test = new Intersection(strategy, startCoords, grid);
            //call add, which tests add
            Car c = new Car(grid, 2, 3);
            test.Add(c);
            //call update and test if the car has moved, which tests update
            test.Update();
            Assert.AreEqual(2, c.Y);
            //call update until the car is removed from the intersection, 
            //and then check if it has, in fact, been removed
            test.Update();
            test.Update();
            test.Update();
            test.Update();
            int counter = 0;
            foreach (Vehicle v in test)
            {
                counter++;
            }
            Assert.AreEqual(0, counter);
        }
    }
}
