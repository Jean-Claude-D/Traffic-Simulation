using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Decorates and IVehicle by
    /// greatly reducing emission values
    /// </summary>
    public class Electric : IVehicle
    {
        /// <summary>
        /// Event fired when this Electric Vehicle has
        /// crossed the entire intersection
        /// </summary>
        public event IVehicleHandler Done;
        /// <summary>
        /// Event fired when this Electric Vehicle's
        /// Move method is called and moved it
        /// </summary>
        public event IVehicleHandler Moved;
        /// <summary>
        /// Event fired when this Electric Vehicle's
        /// Move method is called and did not move it
        /// </summary>
        public event IVehicleHandler Waiting;

        /// <summary>
        /// The IVehicle this
        /// Electric is decorating
        /// </summary>
        public IVehicle IVehicle;

        /// <summary>
        /// Creates an Electric from an IVehicle
        /// </summary>
        /// <param name="vehicle">The IVehicle to decorate</param>
        public Electric(IVehicle vehicle)
        {
            if(vehicle == null)
            {
                throw new ArgumentException("Cannot decorate a null IVehicle");
            }

            /* Getting all event handlers
             * into this Electric */
            this.IVehicle.Done += vehicle.Done;
            this.IVehicle.Moved += vehicle.Moved;
            this.IVehicle.Waiting += vehicle.Waiting;

            this.IVehicle = vehicle;
        }

        /// <summary>
        /// The Direction of the decorated IVehicle
        /// </summary>
        public Direction Direction
        {
            get { return IVehicle.Direction; }
            set { IVehicle.Direction = value; }
        }

        /// <summary>
        /// The X of the decorated IVehicle
        /// </summary>
        public int X
        {
            get { return IVehicle.X; }
            set { IVehicle.X = value; }
        }
        /// <summary>
        /// The Y of the decorated IVehicle
        /// </summary>
        public int Y
        {
            get { return IVehicle.Y; }
            set { IVehicle.Y = value; }
        }

        /// <summary>
        /// The Passengers of the decorated IVehicle
        /// </summary>
        public int Passengers
        {
            get { return IVehicle.Passengers; }
        }

        /// <summary>
        /// The amount of emission unit emitted
        /// when this Electric is waiting (always 0)
        /// </summary>
        public double EmissionIdle
        {
            get { return 0; }
        }
        /// <summary>
        /// The amount of emission unit emitted when this
        /// Electric is moving (less than the decorated IVehicle)
        /// </summary>
        public double EmissionMoving
        {
            get { return IVehicle.EmissionMoving / 4; }
        }

        /// <summary>
        /// Checks if the decorated IVehicle
        /// is on an IntersectionTile
        /// </summary>
        /// <returns>this Electric's IVehicle's
        /// InIntersection()</returns>
        public bool InIntersection()
        {
            return IVehicle.InIntersection();
        }

        /// <summary>
        /// Moves the decorated IVehicle
        /// </summary>
        /// <param name="signal">The traffic lights in the simulation</param>
        public void Move(ISignalStrategy signal)
        {
            IVehicle.Move(signal);
        }

        /// <summary>
        /// Checks if the decorated IVehicle's
        /// next tile is an IntersectionTile
        /// </summary>
        /// <returns>this Electric's IVehicle's
        /// NextIsIntersection()</returns>
        public bool NextIsIntersection()
        {
            return IVehicle.NextIsIntersection();
        }
    }
}
