using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public class Car:Vehicle
    {
        public Car(Grid grid): base(5, 2, 3, grid)
        {
        }
        public Car(Grid grid, int x, int y) : base(5, 2, 3, grid, x, y)
        {
        }
    }
}
