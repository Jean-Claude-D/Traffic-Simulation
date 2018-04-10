using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Represents a square
    /// in the simulation grid
    /// </summary>
    public abstract class Tile
    {
        /// <summary>
        /// The direction this Tile
        /// indicates (useful for Road)
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// Whether or not there is
        /// an IVehicle on this Tile
        /// </summary>
        public bool Occupied;

        /// <summary>
        /// Creates a Tile with a direction
        /// </summary>
        /// <param name="direction">The direction
        /// this Tile indicates</param>
        public Tile(Direction direction)
        {
            Direction = direction;
            Occupied = false;
        }
    }
}
