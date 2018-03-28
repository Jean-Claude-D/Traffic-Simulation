using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrafficLibrary
{
    /// <summary>
    /// The road tile
    /// </summary>
    class Road : Tile
    {
        /// <summary>
        /// Road constructor which passes the direction to the tile class
        /// </summary>
        /// <param name="direction"></param>
        public Road(Direction direction) : base(direction)
        {
            base.occupied = false;
        }
    }
}
