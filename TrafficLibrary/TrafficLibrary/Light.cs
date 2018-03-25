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

        public Light(ISignalStrategy member, Direction d)
        {
            base.direction = d;
            strategy = member;
        }
        public Colour colour;   
    }
}
