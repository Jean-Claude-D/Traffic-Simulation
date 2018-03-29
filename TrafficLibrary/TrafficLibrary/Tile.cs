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
        public Direction Direction;
        public bool Occupied;
        public Tile(Direction direction)
        {
            this.Direction = direction;
        }
    }
}
