using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{

    class FixedSignal : ISignalStrategy
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down,
            None
        }

        private int[] timing;
        private int currentIndex;
        private Colour updown;
        private Colour rightleft;
        private int counter = 0;

        public FixedSignal(params int[] timing)
        {
            this.timing = timing;
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
            //time it takes to run a whole cycle, from green back to green
            int totalCycleTime = 0;
            foreach (int i in timing)
            {
                totalCycleTime += i;
            }

            int cycleTime = counter % totalCycleTime;

            if (cycleTime <= timing[0])
            {
                rightleft = Colour.Green;
                updown = Colour.Red;
            }
            else if (cycleTime <= timing[0] + timing[1])
            {
                rightleft = Colour.Amber;
            }
            else if (cycleTime <= timing[0] + timing[1] + timing[2])
            {
                rightleft = Colour.Red;
                updown = Colour.Green;
            }
            else if (cycleTime <= timing[0] + timing[1] + timing[2] + timing[3])
            {
                updown = Colour.Amber;
            }
            counter++;
        }
    }
}
