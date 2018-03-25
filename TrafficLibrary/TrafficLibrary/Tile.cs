using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        None
    }
    public class Tile
    {
        public Direction direction;
        public bool occupied;
        public Tile(Direction direction, bool occupied)
        {
            this.direction = direction;
            this.occupied = occupied;
        }
    }
}
