using System;
using TrafficLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficTest
{
    [TestClass]
    public class LightTest
    {
        private static int[] _timings = { 20, 5, 10, 5 };

        [TestMethod]
        public void LightConstructor_Valid()
        {
            Light myLight;
            ISignalStrategy myTrafficLight = getTrafficLight();
            Direction myDirection = Direction.Right;

            myLight = new Light(myTrafficLight, myDirection);
        }

        [TestMethod]
        public void LightConstructor_NullISignalstrategy()
        {
            Light myLight;
            ISignalStrategy myTrafficLight = null;
            Direction myDirection = Direction.Right;

            Assert.ThrowsException<ArgumentException>(
                () => myLight = new Light(myTrafficLight, myDirection));
        }

        [TestMethod]
        public void LightConstructor_DirectionNone()
        {
            Light myLight;
            ISignalStrategy myTrafficLight = getTrafficLight();
            Direction myDirection = Direction.None;

            Assert.ThrowsException<ArgumentException>(
                () => myLight = new Light(myTrafficLight, myDirection));
        }

        [TestMethod]
        public void Light_GetColourFirstCycle()
        {
            ISignalStrategy myTrafficLight = getTrafficLight();
            Direction myDirection = Direction.Right;
            Light myLight = new Light(myTrafficLight, myDirection);

            for(int i = 0; i < _timings[0] - 1; i++)
            {
                myTrafficLight.Update();
            }

            Assert.AreEqual(Colour.Green, myLight.colour);
        }

        [TestMethod]
        public void Light_GetColourSecondCycle()
        {
            ISignalStrategy myTrafficLight = getTrafficLight();
            Direction myDirection = Direction.Right;
            Light myLight = new Light(myTrafficLight, myDirection);

            for (int i = 0; i < (_timings[1] - 1) + _timings[0] ; i++)
            {
                myTrafficLight.Update();
            }

            Assert.AreEqual(Colour.Amber, myLight.colour);
        }

        [TestMethod]
        public void Light_GetColourThirdCycle()
        {
            ISignalStrategy myTrafficLight = getTrafficLight();
            Direction myDirection = Direction.Right;
            Light myLight = new Light(myTrafficLight, myDirection);

            for (int i = 0; i < (_timings[2] - 1) + _timings[1] + _timings[0]; i++)
            {
                myTrafficLight.Update();
            }

            Assert.AreEqual(Colour.Red, myLight.colour);
        }

        private ISignalStrategy getTrafficLight()
        {
            return new FixedSignal(_timings);
        }
    }
}
