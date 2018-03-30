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
        public void LightConstructor_ValidISignalstrategy()
        {

        }

        [TestMethod]
        public void LightConstructor_NullISignalstrategy()
        {

        }

        [TestMethod]
        public void LightConstructor_ValidDirection()
        {

        }

        [TestMethod]
        public void LightConstructor_DirectionNone()
        {

        }

        [TestMethod]
        public void Light_GetColourFirstCycle()
        {

        }

        [TestMethod]
        public void Light_GetColourSecondCycle()
        {

        }

        [TestMethod]
        public void Light_GetColourThirdCycle()
        {

        }

        [TestMethod]
        public void Light_GetColourFourthCycle()
        {

        }

        public ISignalStrategy getTrafficLight()
        {
            return new FixedSignal(_timings);
        }
    }
}
