﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public class Total
    {
        /// <summary>
        /// The total number of passengers in all IVehicle
        /// currently in the simulation
        /// </summary>
        public int Passengers
        {
            get;
            private set;
        }
        /// <summary>
        /// The total units of emissions produced by IVehicle
        /// objects to which this Total is subscribed
        /// </summary>
        public double Emissions
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new Total object with a
        /// starting amount of vehicles
        /// </summary>
        /// <param name="totalVehicles">The total number of vehicles</param>
        public Total(int totalVehicles)
        {

        }

        /// <summary>
        /// Handler for IVehicle's Done event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Done event</param>
        public VehicleOver(IVehicle vehicle)
        {

        }
        /// <summary>
        /// Handler for IVehicle's Moved event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Moved event</param>
        public Moved(IVehicle vehicle)
        {

        }

        /// <summary>
        /// Handler for IVehicle's Waiting event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Waiting event</param>
        public Waiting(IVehicle vehicle)
        {

        }
    }
}
