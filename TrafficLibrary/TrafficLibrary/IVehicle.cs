using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public delegate void Handler(IVehicle v);

    public interface IVehicle
    {
        event Handler Done;
        event Handler Moved;
        event Handler Waiting;

        Direction Direction
        {
            get;
        }
        int X
        {
            get;
        }
        int Y
        {
            get;
        }
        int Passengers
        {
            get;
        }
        double EmissionIdle
        {
            get;
        }
        double EmissionMoving
        {
            get;
        }

        void Move(ISignalStrategy signal);

        bool NextIsIntersection();

        bool InIntersection();
    }
}
