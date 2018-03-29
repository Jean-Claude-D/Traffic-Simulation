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
        private int currentIndex = 0;
        private Colour updown = Colour.Red;
        private Colour rightleft = Colour.Red;
        private int totalCycleTime = 0;

        public FixedSignal(params int[] timing)
        {
            for(int i = 0; i < timing.Length; i++)
            {
                this.timing[i] = timing[i];
                totalCycleTime += timing[i];
            }
        }

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
