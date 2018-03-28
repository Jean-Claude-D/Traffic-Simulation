using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLibrary;
using System.Collections.Generic;

namespace TrafficTest
{
    [TestClass]
    public class IntersectionTest
    {
        [TestMethod]
        public void TestUpdate()
        {
            Tile[,] tiles = new Tile[4, 4];
            tiles[0, 0] = new Grass();
            tiles[0, 1] = new Road(Direction.Down);
            tiles[0, 2] = new Road(Direction.Up);
            tiles[0, 3] = new Grass();
            tiles[1, 0] = new Road(Direction.Left);
            tiles[1, 1] = new IntersectionTile();
            tiles[1, 2] = new IntersectionTile();
            tiles[1, 3] = new Road(Direction.Left);
            tiles[2, 0] = new Road(Direction.Right);
            tiles[2, 1] = new IntersectionTile();
            tiles[2, 2] = new IntersectionTile();
            tiles[2, 3] = new Road(Direction.Right);
            tiles[3, 0] = new Grass();
            tiles[3, 1] = new Road(Direction.Down);
            tiles[3, 2] = new Road(Direction.Up);
            tiles[3, 3] = new Grass();

            Grid grid = new Grid(tiles);
            FixedSignal strategy = new FixedSignal(20, 5, 10, 5);
            List<Vector2>
        }
        [TestMethod]
        public void TestAdd()
        {

        }
    }
}
