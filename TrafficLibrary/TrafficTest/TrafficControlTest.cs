using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLibrary;

namespace TrafficTest
{
    [TestClass]
    public class TrafficControlTest
    {
        [TestMethod]
        public void TestParse()
        {
            string content = File.ReadAllText(@"H:\C#\Traffic\TrafficLibrary\TrafficTest\trafficfile.txt");

            TrafficControl tc = new TrafficControl();

            tc.Parse(content);
        }
    }
}
