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
            string file1 = File.ReadAllText(@"..\..\Properties\trafficfile.txt");
            string file2 = File.ReadAllText(@"..\..\..\TrafficTest\Properties\grid.txt");

            TrafficControl tc = new TrafficControl();

            tc.Parse(file1);
            
            Assert.AreEqual(tc.Grid[0, 0].GetType(), typeof(Grass));
            Assert.AreEqual(tc.Grid[1, 1].GetType(), typeof(Grass));
            Assert.AreEqual(tc.Grid[2, 2].GetType(), typeof(Light));
            Assert.AreEqual(tc.Grid[2, 5].GetType(), typeof(Light));
            Assert.AreEqual(tc.Grid[3, 3].GetType(), typeof(IntersectionTile));
            Assert.AreEqual(tc.Grid[3, 4].GetType(), typeof(IntersectionTile));
            Assert.AreEqual(tc.Grid[3, 5].GetType(), typeof(Road));
            Assert.AreEqual(tc.Grid[3, 5].Direction, Direction.Down);
            Assert.AreEqual(tc.Grid[5, 3].Direction, Direction.Left);
            Assert.AreEqual(tc.Grid[0, 5].Direction, Direction.Right);
            Assert.AreEqual(tc.Grid[4, 0].Direction, Direction.Up);
            Assert.IsTrue(tc.Grid.InBounds(7, 7));
            Assert.IsFalse(tc.Grid.InBounds(8, 8));
            

            TrafficControl tc2 = new TrafficControl();

            tc2.Parse(file2);
            //
            Assert.AreEqual(tc2.Grid[0, 0].GetType(), typeof(Grass));
        }

        [TestMethod]
        public void TestUpdate()
        {

        }
    }
}
