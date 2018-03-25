using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    class Electric : IVehicle
    {
        public event Handler Done;
        public event Handler Moved;
        public event Handler Waiting;
        private IVehicle v;

        public Electric(IVehicle v)
        {
            if (v != null)
            {
                this.v = v;
                this.v.Done += Done;
                this.v.Moved += Moved;
                this.v.Waiting += Waiting;
            }
            else
            {
                throw new ArgumentException("Vehicle is null!");
            }
        }
        public Direction Direction
        {
            get { return v.Direction; }
        }
        public int X
        {
            get { return v.X; }
        }
        public int Y
        {
            get { return v.Y; }
        }
        public int Passengers
        {
            get { return v.Passengers; }
        }
        public double EmissionIdle
        {
            get { return 0; }
        }
        public double EmissionMoving
        {
            get { return v.EmissionMoving / 4; }
        }

        


        public bool InIntersection()
        {
            return v.InIntersection();
        }

        public void Move(ISignalStrategy signal)
        {
            v.Move(signal);
        }

        public bool NextIsIntersection()
        {
            return v.NextIsIntersection();
        }
    }
}
