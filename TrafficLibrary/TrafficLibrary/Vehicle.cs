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
        public Vehicle(double emissionMoving, double emissionIdle, int passengers, Grid grid)
            : this(emissionMoving, emissionIdle, passengers, grid, default(int), default(int))
        { }

        public Vehicle(double emissionMoving, double emissionIdle, int passengers, Grid grid, int x, int y)
        {
            if(grid == null)
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

        private Grid _grid;

        private Boolean isLocationAnIntersection(int x, int y)
        {
            return !isLocationOutOfBounds(x, y) &&
                _grid[x, y].GetType().Equals(typeof(IntersectionTile));
        }

        public Direction Direction
        {
            get;
            set;
        }

        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }

        private Boolean isOutOfBounds()
        {
            return isLocationOutOfBounds(X, Y);
        }

        private Boolean isLocationOutOfBounds(int x, int y)
        {
            return x >= _grid.Size || y >= _grid.Size
                || x < 0 || y < 0;
        }

        public int Passengers
        {
            get;
        }

        public double EmissionIdle
        {
            get;
        }
        public double EmissionMoving
        {
            get;
        }

        public event IVehicleHandler Done;
        public event IVehicleHandler Moved;
        public event IVehicleHandler Waiting;

        public bool InIntersection()
        {
            return isOutOfBounds() || isLocationAnIntersection(X, Y);
        }

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

        private void move(int x, int y, ISignalStrategy signal)
        {

            if(isLocationOutOfBounds(x, y))
            {
                _grid[X, Y].Occupied = false;
                Done?.Invoke(this);
            }
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
