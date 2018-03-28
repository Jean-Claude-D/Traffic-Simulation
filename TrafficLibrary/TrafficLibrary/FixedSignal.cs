using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public class FixedSignal : ISignalStrategy
    {
        private int[] timing;
        private int currentIndex;
        private Colour updown;
        private Colour rightleft;
        private int counter;

        public FixedSignal(params int[] timing)
        {
            throw new NotImplementedException();
        }

        public Colour GetColour(Direction dir)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
