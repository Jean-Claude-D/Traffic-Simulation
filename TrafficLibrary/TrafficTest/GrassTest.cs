using System;
using TrafficLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficTest
{
    [TestClass]
    public class GrassTest
    {
        [TestMethod]
        public void GrassConstructor_CheckOccupied()
        {
            Grass myGrass;
            bool expected = false;

            myGrass = new Grass();

            Assert.AreEqual(expected, myGrass.Occupied);
        }

        [TestMethod]
        public void GrassConstructor_CheckDirection()
        {
            Grass myGrass;
            Direction expected = Direction.None;

            myGrass = new Grass();

            Assert.AreEqual(expected, myGrass.Direction);
        }
    }
}
