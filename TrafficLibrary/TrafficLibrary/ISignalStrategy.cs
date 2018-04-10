using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Strategy used for changing
    /// traffic lights colours
    /// </summary>
    public interface ISignalStrategy
    {
        /// <summary>
        /// Updates this ISignalStrategy
        /// (every simulation tick)
        /// </summary>
        void Update();

        /// <summary>
        /// Gets the current Colour of this
        /// ISignalStrategy for a given Direction
        /// </summary>
        /// <param name="dir">The Direction to
        /// get the colour for</param>
        /// <returns>The Colour this
        /// traffic light shows</returns>
        Colour GetColour(Direction dir);
    }
}