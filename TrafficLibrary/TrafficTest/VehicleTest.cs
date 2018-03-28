using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficTest
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            try
            {
                VehicleTest v = new V(12.34, 12.34, 5, null);
                
            }
            catch (ArgumentException e) { }
        }
    }
}
