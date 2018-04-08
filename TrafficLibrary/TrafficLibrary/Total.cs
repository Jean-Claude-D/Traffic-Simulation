﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Holds data of statistics
    /// about the simulation
    /// </summary>
    public class Total
    {
        /// <summary>
        /// The total number of passengers that made
        /// it alive through the intersection
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
        /// Creates a new Total object
        /// </summary>
        public Total()
        { }

        /// <summary>
        /// Handler for IVehicle's Done event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Done event</param>
        public void VehicleOver(IVehicle vehicle)
        {
            Passengers += vehicle.Passengers;
        }
        /// <summary>
        /// Handler for IVehicle's Moved event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Moved event</param>
        public void Moved(IVehicle vehicle)
        {
            Emissions += vehicle.EmissionMoving;
        }

        /// <summary>
        /// Handler for IVehicle's Waiting event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Waiting event</param>
        public void Waiting(IVehicle vehicle)
        {
            Emissions += vehicle.EmissionIdle;
        }
    }
}
