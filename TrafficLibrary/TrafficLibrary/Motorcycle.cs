using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    class Motorcycle:Vehicle
    {
        public Motorcycle(Grid grid): base(2, 1, 1, grid)
        {
        }
        public Motorcycle(Grid grid, int x, int y) : base(2, 1, 1, grid, x, y)
        {
        }
    }
}
