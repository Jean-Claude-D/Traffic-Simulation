using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Tile abstract class
    /// </summary>
    public abstract class Tile
    {
        public Direction direction;
        public bool occupied;
        public Tile(Direction direction)
        {
            this.direction = direction;
        }
    }
}
