using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public class Electric : IVehicle
    {
        public event Handler Done;
        public event Handler Moved;
        public event Handler Waiting;
        public IVehicle Vehicle;

        public Electric(IVehicle v)
        {
            if (v != null)
            {
                this.Vehicle = v;
                this.Vehicle.Done += Done;
                this.Vehicle.Moved += Moved;
                this.Vehicle.Waiting += Waiting;
            }
            else
            {
                throw new ArgumentException("Vehicle is null!");
            }
        }
        public Direction Direction
        {
            get { return Vehicle.Direction; }
            set { Vehicle.Direction = value; }
        }
        public int X
        {
            get { return Vehicle.X; }
            set { Vehicle.X = value; }
        }
        public int Y
        {
            get { return Vehicle.Y; }
            set { Vehicle.Y = value; }
        }
        public int Passengers
        {
            get { return Vehicle.Passengers; }
        }
        public double EmissionIdle
        {
            get { return 0; }
        }
        public double EmissionMoving
        {
            get { return Vehicle.EmissionMoving / 4; }
        }

        public bool InIntersection()
        {
            return Vehicle.InIntersection();
        }

        public void Move(ISignalStrategy signal)
        {
            Vehicle.Move(signal);
        }

        public bool NextIsIntersection()
        {
            return Vehicle.NextIsIntersection();
        }
    }
}
