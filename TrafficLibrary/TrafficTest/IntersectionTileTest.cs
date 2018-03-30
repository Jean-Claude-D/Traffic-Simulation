using System;
using TrafficLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficTest
{
    [TestClass]
    public class IntersectionTileTest
    {
        [TestMethod]
        public void IntersectionTileConstructor_CheckOccupied()
        {
            IntersectionTile myIntersectionTile;
            bool expected = false;

            myIntersectionTile = new IntersectionTile();

            Assert.AreEqual(expected, myIntersectionTile.Occupied);
        }

        [TestMethod]
        public void IntersectionTileConstructor_CheckDirection()
        {
            IntersectionTile myIntersectionTile;
            Direction expected = Direction.None;

            myIntersectionTile = new IntersectionTile();

            Assert.AreEqual(expected, myIntersectionTile.Direction);
        }
    }
}
