using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Handle for events fired by an IVehicle
    /// </summary>
    /// <param name="v"></param>
    public delegate void IVehicleHandler(IVehicle iVehicle);

    /// <summary>
    /// Represents any automotive transport
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Event fired when this IVehicle has
        /// crossed the entire intersection
        /// </summary>
        event IVehicleHandler Done;
        /// <summary>
        /// Event fired when this IVehicle's
        /// Move method is called and moved it
        /// </summary>
        event IVehicleHandler Moved;
        /// <summary>
        /// Event fired when this IVehicle's
        /// Move method is called and did not move it
        /// </summary>
        event IVehicleHandler Waiting;

        /// <summary>
        /// This IVehicle's movement direction
        /// </summary>
        Direction Direction
        {
            get;set;
        }

        /// <summary>
        /// This IVehicle's position on the x-axis
        /// </summary>
        int X
        {
            get;set;
        }
        /// <summary>
        /// This IVehicle's position on the y-axis
        /// </summary>
        int Y
        {
            get;set;
        }

        /// <summary>
        /// The number of passengers aboard this IVehicle
        /// </summary>
        int Passengers
        {
            get;
        }

        /// <summary>
        /// The amount of emission unit emitted
        /// by this IVehicle when waiting
        /// </summary>
        double EmissionIdle
        {
            get;
        }
        /// <summary>
        /// The amount of emission unit emitted
        /// by this IVehicle when moving
        /// </summary>
        double EmissionMoving
        {
            get;
        }

        /// <summary>
        /// Moves this IVehicle in its Direction,
        /// follows the given signal and
        /// fires all appropriate events
        /// </summary>
        /// <param name="signal">The traffic lights in the simulation</param>
        void Move(ISignalStrategy signal);

        /// <summary>
        /// Checks if the Tile relative to this
        /// IVehicle's X and Y position in this
        /// IVehicle's Direction is an IntersectionTile
        /// </summary>
        /// <returns>true if the next tile is an
        /// IntersectionTile, false otherwise</returns>
        bool NextIsIntersection();

        /// <summary>
        /// Checks if the Tile at this IVehicle's
        /// X and Y is an IntersectionTile
        /// </summary>
        /// <returns>true if the current tile is an
        /// IntersectionTile, false otherwise</returns>
        bool InIntersection();
    }
}
