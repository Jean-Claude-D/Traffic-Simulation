using System;
using TrafficLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficTest
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void Constructor_NullTileArr()
        {
            Grid myGrid;
            Tile[,] myTileArr = null;

            Assert.ThrowsException<ArgumentException>(
                () => myGrid = new Grid(myTileArr)
                );
        }

        [TestMethod]
        public void Constructor_NotFilledTileArr()
        {
            Grid myGrid;
            Tile[,] myTileArr = {
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), null, new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {null, new Grass(), new Grass(), new Grass() } };

            Assert.ThrowsException<ArgumentException>(
                () => myGrid = new Grid(myTileArr)
                );
        }

        [TestMethod]
        public void Constructor_NotSquareTileArr()
        {
            Grid myGrid;
            Tile[,] myTileArr = {
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() } };

            Assert.ThrowsException<ArgumentException>(
                () => myGrid = new Grid(myTileArr)
                );
        }

        [TestMethod]
        public void Constructor_SmallTileArr()
        {
            Grid myGrid;
            Tile[,] myTileArr = {
                {new Grass(), new Grass() },
                {new Grass(), new Grass() }};

            Assert.ThrowsException<ArgumentException>(
                () => myGrid = new Grid(myTileArr)
                );
        }

        [TestMethod]
        public void Constructor_ValidTileArr()
        {
            Grid myGrid;
            Tile[,] myTileArr = {
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() },
                {new Grass(), new Grass(), new Grass(), new Grass() } };

            try
            {
                myGrid = new Grid(myTileArr);
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Indexer_Valid()
        {
            Grid myGrid = new Grid(getGrassTileArr());
            bool noException = false;

            try
            {
                Assert.ThrowsException<IndexOutOfRangeException>(
                    () =>
                    {
                        Tile myTile;
                        for(int i = 0; i < myGrid.Size; i++)
                        {
                            for(int j = 0; j < myGrid.Size; j++)
                            {
                                myTile = myGrid[i, j];
                            }
                        }
                    });
            }
            catch(AssertFailedException)
            {
                noException = true;
            }

            Assert.IsTrue(noException);
        }

        [TestMethod]
        public void Indexer_OutOfBound()
        {
            Grid myGrid = new Grid(getGrassTileArr());
            Tile myTile;

            Assert.ThrowsException<IndexOutOfRangeException>(
                () => myTile = myGrid[0, 5]);
        }

        [TestMethod]
        public void IsOccupied_True()
        {
            Tile[,] myTileArr = getGrassTileArr();
            Grid myGrid = new Grid(myTileArr);
            bool expected = true;

            myTileArr[0, 3].Occupied = expected;

            Assert.AreEqual(expected, myGrid.IsOccupied(0, 3));
        }

        [TestMethod]
        public void IsOccupied_False()
        {
            Tile[,] myTileArr = getGrassTileArr();
            Grid myGrid = new Grid(myTileArr);
            bool expected = false;

            myTileArr[0, 3].Occupied = expected;

            Assert.AreEqual(expected, myGrid.IsOccupied(0, 3));
        }

        [TestMethod]
        public void IsOccupied_OutOfBoundIndexes()
        {
            Grid myGrid = new Grid(getGrassTileArr());
            bool isOccupied;

            Assert.ThrowsException<IndexOutOfRangeException>(
                () => isOccupied = myGrid.IsOccupied(3, 4));
        }

        [TestMethod]
        public void InBounds_True()
        {
            Grid myGrid = new Grid(getGrassTileArr());
            bool expected = true;

            Assert.AreEqual(expected, myGrid.InBounds(3, 3));
        }

        [TestMethod]
        public void InBounds_False()
        {
            Grid myGrid = new Grid(getGrassTileArr());
            bool expected = false;

            Assert.AreEqual(expected, myGrid.InBounds(0, 4));
        }

        private static Tile[,] getGrassTileArr()
        {
            Tile[,] myTileArr = {
                { new Grass(), new Grass(), new Grass(), new Grass() },
                { new Grass(), new Grass(), new Grass(), new Grass() },
                { new Grass(), new Grass(), new Grass(), new Grass() },
                { new Grass(), new Grass(), new Grass(), new Grass() }
            };

            return myTileArr;
        }
    }
}
