using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// The intersection between crossing
    /// roads of different directions
    /// </summary>
    public class IntersectionTile : Tile
    {
        /// <summary>
        /// Creates a new IntersectionTile
        /// with Direction None
        /// </summary>
        public IntersectionTile() : base(Direction.None)
        { }
    }
}
