using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// FixedSignal class handling the colour of the lights 
    /// and their timings
    /// </summary>
    public class FixedSignal : ISignalStrategy
    {
        private int[] timing;
        private int currentIndex = 0;
        private Colour updown = Colour.Red;
        private Colour rightleft = Colour.Red;
        private int totalCycleTime = 0;

        /// <summary>
        /// FixedSignal Constructor
        /// </summary>
        /// <param name="timing">Light signal timings</param>
        public FixedSignal(params int[] timing)
        {
            this.timing = new int[timing.Length];
            for(int i = 0; i < timing.Length; i++)
            {
                this.timing[i] = timing[i];
                totalCycleTime += timing[i];
            }
        }

        /// <summary>
        /// Returns the color of the light, depending of what road it is
        /// </summary>
        /// <param name="dir">The road direction</param>
        /// <returns>The colour of the light, given its direction</returns>
        public Colour GetColour(Direction dir)
        {
            if (dir == Direction.None)
            {
                throw new ArgumentException("Can't return a colour when direction is None");
            }
            else if (dir == Direction.Right || dir == Direction.Left)
            {
                return rightleft;
            }
            else
            {
                return updown;
            }
        }

        /// <summary>
        /// Assigns the colour of the lights for each road, depending
        /// on where it is in the timing cycle
        /// </summary>
        public void Update()
        {
            currentIndex %= totalCycleTime;

            if (currentIndex <= timing[0])
            {
                rightleft = Colour.Green;
                updown = Colour.Red;
            }
            else if (currentIndex <= timing[0] + timing[1])
            {
                rightleft = Colour.Amber;
            }
            else if (currentIndex <= timing[0] + timing[1] + timing[2])
            {
                rightleft = Colour.Red;
                updown = Colour.Green;
            }
            else if (currentIndex <= timing[0] + timing[1] + timing[2] + timing[3])
            {
                updown = Colour.Amber;
            }
            currentIndex++;
        }
    }
}
