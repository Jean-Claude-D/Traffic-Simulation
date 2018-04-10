using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Standard Vehicle implementation with
    /// medium emission and passengers level
    /// </summary>
    public class Car:Vehicle
    {
        /// <summary>
        /// Creates a Car object
        /// on a specific Grid
        /// </summary>
        /// <param name="grid">The Grid on which the Car is</param>
        public Car(Grid grid): base(5, 2, 3, grid)
        { }

        /// <summary>
        /// Creates a Car object on
        /// Grid at a specific position
        /// </summary>
        /// <param name="grid">The Grid on which the Car is</param>
        /// <param name="x">The column of the tile on which the Car is</param>
        /// <param name="y">The row of the tile on which the Car is</param>
        public Car(Grid grid, int x, int y) : base(5, 2, 3, grid, x, y)
        { }
    }
}
