﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    delegate void Handler(IVehicle v);

    enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    interface IVehicle
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
