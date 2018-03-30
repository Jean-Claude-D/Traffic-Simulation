using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrafficLibrary
{
    /// <summary>
    /// Light class representing each light tile
    /// </summary>
    public class Light : Tile
    {
        private ISignalStrategy strategy;
        /// <summary>
        /// Light constructor instantiating a light tile with a direction
        /// </summary>
        /// <param name="member"></param>
        /// <param name="d"></param>
        public Light(ISignalStrategy member, Direction d) : base(d)
        {
            if(member == null)
            {
                throw new ArgumentException("Cannot have null member");
            }
            if(d == Direction.None)
            {
                throw new ArgumentException("Cannot have Direction.None direction");
            }
            Direction = d;
            strategy = member;
        }
        /// <summary>
        /// The color property which determines the color of the light
        /// </summary>
        public Colour Colour 
        {
            get { return strategy.GetColour(this.Direction); } 
            private set { Colour = value; }
        } 
    }
}
