using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Strategy that controls how each of the lights operate
    /// </summary>
    public interface ISignalStrategy
    {
        /// <summary>
        /// Assigns the colour of the lights for each road, depending
        /// on where it is in the timing cycle
        /// </summary>
        void Update();

        /// <summary>
        /// Returns the color of the light, depending of what road it is
        /// </summary>
        /// <param name="dir">The road direction</param>
        /// <returns>The colour of the light, given its direction</returns>
        Colour GetColour(Direction dir);
    }
}