using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
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
        /// Creates a new Total object with a
        /// starting amount of vehicles
        /// </summary>
        public Total()
        {

        }

        /// <summary>
        /// Handler for IVehicle's Done event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Done event</param>
        public void VehicleOver(IVehicle vehicle)
        {

        }
        /// <summary>
        /// Handler for IVehicle's Moved event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Moved event</param>
        public void Moved(IVehicle vehicle)
        {

        }

        /// <summary>
        /// Handler for IVehicle's Waiting event
        /// </summary>
        /// <param name="vehicle">The IVehicle that fires the Waiting event</param>
        public void Waiting(IVehicle vehicle)
        {

        }
    }
}
