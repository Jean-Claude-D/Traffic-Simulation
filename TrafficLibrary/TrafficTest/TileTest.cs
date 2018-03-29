using System;
using TrafficLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficTest
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void TestConstructor_WithDirection()
        {
            Tile myTile;
            Direction expected = Direction.Right;

            myTile = new TileMock(expected);

            Assert.AreEqual(expected, myTile.Direction);
        }

        [TestMethod]
        public void TestConstructor_WithDirectionNone()
        {
            Tile myTile;
            Direction expected = Direction.None;

            myTile = new TileMock(expected);

            Assert.AreEqual(expected, myTile.Direction);
        }
    }

    internal class TileMock : Tile
    {
        internal TileMock(Direction dir) : base(dir)
        { }
    }
}
