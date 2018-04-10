using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Implementation of ISignalStrategy which
    /// changes colours based on a fixed timer
    /// </summary>
    public class FixedSignal : ISignalStrategy
    {
        /// <summary>
        /// Timings for green and amber for right-left,
        /// and green and amber for up-down
        /// </summary>
        private int[] _timings;

        /// <summary>
        /// The number of ticks it takes
        /// for a complete cycle to happen
        /// </summary>
        private int _totalCycleTime;

        /// <summary>
        /// The tick at which this FixedSignal
        /// is (used to indicate timing)
        /// </summary>
        private int _currTick = 0;

        /// <summary>
        /// The traffic light colour
        /// for up-down direction
        /// </summary>
        private Colour _updown = Colour.Red;
        /// <summary>
        /// The traffic light colour
        /// for right-left direction
        /// </summary>
        private Colour _rightleft = Colour.Red;

        /// <summary>
        /// Creates a new FixedSignal with specific timings
        /// </summary>
        /// <param name="timings">Timings for light colours</param>
        public FixedSignal(params int[] timings)
        {
            if(timings == null)
            {
                throw new ArgumentException("timings cannot be null");
            }
            else if(timings.Length != 4)
            {
                throw new ArgumentException
                    ("The length of timings (" + timings.Length + ") should be 4");
            }

            _timings = new int[timings.Length];
            for(int i = 0; i < timings.Length; i++)
            {
                _timings[i] = timings[i];
                _totalCycleTime += timings[i];
            }
        }

        /// <summary>
        /// Gets the traffic light
        /// color for a given direction
        /// </summary>
        /// <param name="direction">The direction for
        /// which to get the colour</param>
        /// <returns>The Colour for the Direction</returns>
        public Colour GetColour(Direction direction)
        {
            switch(direction)
            {
                case Direction.Right:
                case Direction.Left:
                    return _rightleft;
                case Direction.Up:
                case Direction.Down:
                    return _updown;
                default:
                    throw new ArgumentException
                        ("Direction (" + direction + ") is not valid to get a colour");
            }
        }

        /// <summary>
        /// Updates colours for the traffic
        /// light accordingly to the incrementing
        /// current tick counter
        /// </summary>
        public void Update()
        {
            /* Restrain _currTick */
            _currTick %= _totalCycleTime;

            if (_currTick <= _timings[0])
            {
                _rightleft = Colour.Green;
                _updown = Colour.Red;
            }
            else if (_currTick <= _timings[0] + _timings[1])
            {
                _rightleft = Colour.Amber;
            }
            else if (_currTick <= _timings[0] + _timings[1] + _timings[2])
            {
                _rightleft = Colour.Red;
                _updown = Colour.Green;
            }
            else if (_currTick <= _timings[0] + _timings[1] + _timings[2] + _timings[3])
            {
                _updown = Colour.Amber;
            }
            _currTick++;
        }
    }
}
