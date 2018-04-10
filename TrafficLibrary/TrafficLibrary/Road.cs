using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrafficLibrary
{
    /// <summary>
    /// The road on which
    /// IVehicles travel
    /// </summary>
    public class Road : Tile
    {
        /// <summary>
        /// Creates a Road with a given direction
        /// </summary>
        /// <param name="direction">The orientation of the road</param>
        public Road(Direction direction) : base(direction)
        { }
    }
}
