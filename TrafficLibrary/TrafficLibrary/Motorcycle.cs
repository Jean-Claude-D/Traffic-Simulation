using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Standard Vehicle implementation with
    /// light emission level and one passengers
    /// </summary>
    public class Motorcycle:Vehicle
    {
        /// <summary>
        /// Creates a Motorcycle object
        /// on a specific Grid
        /// </summary>
        /// <param name="grid">The Grid on which the Motocycle is</param>
        public Motorcycle(Grid grid): base(2, 1, 1, grid)
        { }

        /// <summary>
        /// Creates a Motocycle object on
        /// Grid at a specific position
        /// </summary>
        /// <param name="grid">The Grid on which the Motorcycle is</param>
        /// <param name="x">The column of the tile on which the Motorcycle is</param>
        /// <param name="y">The row of the tile on which the Motorcycle is</param>
        public Motorcycle(Grid grid, int x, int y) : base(2, 1, 1, grid, x, y)
        { }
    }
}
