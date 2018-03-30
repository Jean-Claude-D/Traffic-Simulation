using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    
    public class IntersectionTile : Tile
    {
        /// <summary>
        /// Constructor that makes an IntersectionTile and passes none to the direction because intersection tiles cannot have a direction
        /// </summary>
        public IntersectionTile() : base(Direction.None)
        {
            Occupied = false;
        }
    }
}
