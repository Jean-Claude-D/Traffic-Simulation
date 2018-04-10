using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrafficLibrary
{
    /// <summary>
    /// Represents a traffic light
    /// for a specific direction
    /// </summary>
    public class Light : Tile
    {
        /// <summary>
        /// Dictates the colour
        /// cycle of this Light tile
        /// </summary>
        private ISignalStrategy _strategy;

        /// <summary>
        /// Creates a Light for a given direction
        /// </summary>
        /// <param name="strategy">The strategy
        /// dictating colour changes</param>
        /// <param name="direction">The direction for
        /// which this Light shows the colour</param>
        public Light(ISignalStrategy strategy, Direction direction) : base(direction)
        {
            if(strategy == null)
            {
                throw new ArgumentException("strategy cannot be null");
            }
            else if(direction == Direction.None)
            {
                throw new ArgumentException("direction cannot be Direction None");
            }

            _strategy = strategy;
        }

        /// <summary>
        /// The colour this Light
        /// indicates for its Direction
        /// </summary>
        public Colour Colour 
        {
            get { return _strategy.GetColour(Direction); }
        } 
    }
}
