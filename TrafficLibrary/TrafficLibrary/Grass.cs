using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Grass tile that inherets from tile
    /// </summary>
    public class Grass : Tile
    {
        /// <summary>
        /// Passing the base class no direction as grass cannot have a direction
        /// </summary>
        public Grass() : base(Direction.None)
        {
            base.occupied = false;
        }
    }
}
