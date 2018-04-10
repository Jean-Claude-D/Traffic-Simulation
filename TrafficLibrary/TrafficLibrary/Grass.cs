using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Empty grass tile
    /// </summary>
    public class Grass : Tile
    {
        /// <summary>
        /// Creates a new Grass
        /// with Direction None
        /// </summary>
        public Grass() : base(Direction.None)
        { }
    }
}
