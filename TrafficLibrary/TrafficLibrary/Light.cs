using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public class Light : Tile
    {
        private ISignalStrategy strategy;

        public Light(ISignalStrategy member, Direction d) : base(d)
        {
            base.direction = d;
            base.occupied = false;
            strategy = member;
        }
        public Colour colour = GetColour(strategy);  
    }
}
