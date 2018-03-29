using System;
using TrafficLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficTest
{
    public class TileTest
    {
    }

    public class TileMock : Tile
    {
        public TileMock(Direction dir) : base(dir)
        { }
    }
}
