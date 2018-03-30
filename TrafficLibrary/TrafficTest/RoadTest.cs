using System;
using TrafficLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficTest
{
    [TestClass]
    public class RoadTest
    {
        [TestMethod]
        public void RoadConstructor_WithDirectionNone()
        {
            Road myRoad;
            Direction expected = Direction.None;

            myRoad = new Road(expected);

            Assert.AreEqual(expected, myRoad.Direction);
        }

        [TestMethod]
        public void RoadConstructor_WithDirection()
        {
            Road myRoad;
            Direction expected = Direction.Right;

            myRoad = new Road(expected);

            Assert.AreEqual(expected, myRoad.Direction);
        }

        [TestMethod]
        public void RoadConstructor_CheckOccupied()
        {
            Road myRoad;
            bool expected = false;

            myRoad = new Road(Direction.Right);

            Assert.AreEqual(expected, myRoad.Occupied);
        }
    }
}
