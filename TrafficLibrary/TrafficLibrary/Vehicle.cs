using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Basic implementation of IVehicle
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        /// <summary>
        /// Creates a new Vehicle object with specific
        /// emission values, passenger numbers and position
        /// </summary>
        /// <param name="emissionMoving">The amount of emission unit emitted
        /// by this Vehicle when moving</param>
        /// <param name="emissionIdle">The amount of emission unit emitted
        /// by this Vehicle when waiting</param>
        /// <param name="passengers">The number of passengers aboard this Vehicle</param>
        /// <param name="grid">The Grid on which this Vehicle is</param>
        /// <param name="x">This Vehicle's position on the x-axis</param>
        /// <param name="y">This Vehicle's position on the y-axis</param>
        public Vehicle(double emissionMoving, double emissionIdle, int passengers, Grid grid, int x, int y)
        {
            if (grid == null)
            {
                throw new ArgumentException("grid cannot be null");
            }

            this._grid = grid;
            this.Direction = grid[x, y].Direction;

            this.X = x;
            this.Y = y;

            this.Passengers = passengers;

            this.EmissionMoving = emissionMoving;
            this.EmissionIdle = emissionIdle;
        }

        /// <summary>
        /// Creates a new Vehicle object with specific
        /// emission values and passenger numbers
        /// </summary>
        /// <param name="emissionMoving">The amount of emission unit emitted
        /// by this Vehicle when moving</param>
        /// <param name="emissionIdle">The amount of emission unit emitted
        /// by this Vehicle when waiting</param>
        /// <param name="passengers">The number of passengers aboard this Vehicle</param>
        /// <param name="grid">The Grid on which this Vehicle is</param>
        public Vehicle(double emissionMoving, double emissionIdle, int passengers, Grid grid)
            : this(emissionMoving, emissionIdle, passengers, grid, default(int), default(int))
        { }

        /// <summary>
        /// The Grid on which this Vehicle is
        /// </summary>
        private Grid _grid;

        /// <summary>
        /// Checks if the tile at the given
        /// x and y is an IntersectionTile
        /// </summary>
        /// <param name="x">The column of the tile to check</param>
        /// <param name="y">The row of the tile to check</param>
        /// <returns>false if the x and y are out of bounds or</returns>
        private Boolean isLocationAnIntersection(int x, int y)
        {
            return !isLocationOutOfBounds(x, y) &&
                _grid[x, y].GetType().Equals(typeof(IntersectionTile));
        }

        /// <summary>
        /// This Vehicle's movement direction
        /// </summary>
        public Direction Direction
        {
            get;
            set;
        }

        /// <summary>
        /// This IVehicle's position on the x-axis
        /// </summary>
        public int X
        {
            get;
            set;
        }
        /// <summary>
        /// This IVehicle's position on the y-axis
        /// </summary>
        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Checks if this Vehicle is out
        /// of the bounds of its _grid
        /// </summary>
        /// <returns>true if this Vehicle is
        /// out of bounds, false otherwise</returns>
        private Boolean isOutOfBounds()
        {
            return isLocationOutOfBounds(X, Y);
        }

        /// <summary>
        /// Checks if the given x and y are out
        /// of bounds of this Vehicle's _grid
        /// </summary>
        /// <param name="x">The x value of the position to check</param>
        /// <param name="y">The y value of the position to check</param>
        /// <returns>true if either x or y is out of bounds</returns>
        private Boolean isLocationOutOfBounds(int x, int y)
        {
            return x >= _grid.Size || y >= _grid.Size
                || x < 0 || y < 0;
        }

        /// <summary>
        /// The number of passengers aboard this Vehicle
        /// </summary>
        public int Passengers
        {
            get;
        }

        /// <summary>
        /// The amount of emission unit emitted
        /// by this Vehicle when waiting
        /// </summary>
        public double EmissionIdle
        {
            get;
        }
        /// <summary>
        /// The amount of emission unit emitted
        /// by this Vehicle when moving
        /// </summary>
        public double EmissionMoving
        {
            get;
        }

        /// <summary>
        /// Event fired when this Vehicle has
        /// crossed the entire intersection
        /// </summary>
        public event IVehicleHandler Done;
        /// <summary>
        /// Event fired when this Vehicle's
        /// Move method is called and moved it
        /// </summary>
        public event IVehicleHandler Moved;
        /// <summary>
        /// Event fired when this Vehicle's
        /// Move method is called and did not move it
        /// </summary>
        public event IVehicleHandler Waiting;

        /// <summary>
        /// Checks if this Vehicle is
        /// on an IntersectionTile
        /// </summary>
        /// <returns>false if this Vehicle is out of
        /// bounds or not on an IntersectionTile</returns>
        public bool InIntersection()
        {
            return !isOutOfBounds() && isLocationAnIntersection(X, Y);
        }

        /// <summary>
        /// Moves this Vehicle in its Direction,
        /// follows the given signal and
        /// fires all appropriate events
        /// </summary>
        /// <param name="signal">The traffic lights in the simulation</param>
        public void Move(ISignalStrategy signal)
        {
            switch (this.Direction)
            {
                case Direction.Down:
                    move(X, Y + 1, signal);
                    break;
                case Direction.Up:
                    move(X, Y - 1, signal);
                    break;
                case Direction.Left:
                    move(X - 1, Y, signal);
                    break;
                case Direction.Right:
                    move(X + 1, Y, signal);
                    break;
                default:
                    throw new Exception
                        ("Direction of this Vehicle (" + Direction + ") should never be Direction.None");
            }
        }

        /// <summary>
        /// Moves this Vehicle at given x and y,
        /// follows the given signal and
        /// fires all appropriate events
        /// 
        /// Helper method for Move()
        /// </summary>
        /// <param name="x">Column of the target tile</param>
        /// <param name="y">Row of the target tile</param>
        /// <param name="signal">The traffic lights in the simulation</param>
        private void move(int x, int y, ISignalStrategy signal)
        {
            /* If this Vehicle is out of bounds,
             * he has crossed the intersection */
            if(isLocationOutOfBounds(x, y))
            {
                _grid[X, Y].Occupied = false;
                Done?.Invoke(this);
            }
            /* Must follow traffic lights and
             * move where space is available */
            else if(((!NextIsIntersection()) ||
                InIntersection() ||
                signal.GetColour(this.Direction) == Colour.Green)
                && !_grid[x, y].Occupied)
            {
                _grid[X, Y].Occupied = false;
                X = x;
                Y = y;
                _grid[X, Y].Occupied = true;
                Moved?.Invoke(this);
            }
            else
            {
                Waiting?.Invoke(this);
            }
        }

        /// <summary>
        /// Checks if the tile in this Vehicle's
        /// Direction is an IntersectionTile
        /// </summary>
        /// <returns>false if the next tile is out
        /// of bounds or not an IntersectionTile</returns>
        public bool NextIsIntersection()
        {
            switch (this.Direction)
            {
                case Direction.Down:
                    return isLocationAnIntersection(X, Y + 1);
                case Direction.Up:
                    return isLocationAnIntersection(X, Y - 1);
                case Direction.Left:
                    return isLocationAnIntersection(X - 1, Y);
                case Direction.Right:
                    return isLocationAnIntersection(X + 1, Y);
                default:
                    return false;
            };
        }
    }
}
