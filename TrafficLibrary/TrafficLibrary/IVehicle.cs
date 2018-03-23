using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public delegate void Handler();

    enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    };

    interface IVehicle
    {
        event Handler Done;
        event Handler Moved;
        event Handler Waiting;

        Direction Direction
        {
            get; set;
        }
        int X
        {
            get; set;
        }
        int Y
        {
            get; set;
        }
        int Passengers
        {
            get; set;
        }
        double EmissionIdle
        {
            get; set;
        }
        double EmissionMoving
        {
            get; set;
        }

        void Move(ISignalStrategy signal);

        bool NextIsIntersection();

        bool InIntersection();
    }
}
