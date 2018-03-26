using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public abstract class Vehicle : IVehicle
    {
        private Direction direction;
        private int x;
        private int y;
        private int passengers;
        private double emissionIdle;
        private double emissionMoving;
        private Grid grid;

        public Vehicle(double emissionMoving, double emissionIdle, int passengers, Grid grid)
        {
            if (grid != null)
            {
                this.emissionMoving = emissionMoving;
                this.emissionIdle = emissionIdle;
                this.passengers = passengers;
                this.grid = grid;
                this.direction = grid[x, y].Direction;
            }
            else
            {
                throw new ArgumentException("Null Grid!");
            }
        }

        public Vehicle(double emissionMoving, double emissionIdle, int passengers, Grid grid, int x, int y)
        {
            this.emissionMoving = emissionMoving;
            this.emissionIdle = emissionIdle;
            this.passengers = passengers;
            this.grid = grid;
            this.x = x;
            this.y = y;
            this.direction = grid[x, y].Direction;
        }

        public Direction Direction
        {
            get { return this.direction; }
        }
        public int X
        {
            get { return this.x; }
        }
        public int Y
        {
            get { return this.y; }
        }
        public int Passengers
        {
            get { return this.passengers; }
        }
        public double EmissionIdle
        {
            get { return this.emissionIdle; }
        }
        public double EmissionMoving
        {
            get { return this.emissionMoving; }
        }

        public event Handler Done;
        public event Handler Moved;
        public event Handler Waiting;

        public bool InIntersection()
        {
            if(grid[x,y].GetType() == typeof(IntersectionTile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move(ISignalStrategy signal)
        {
            if((!NextIsIntersection()) || InIntersection() || signal.getColour() == Colour.Green)
            {
                switch (this.direction)
                {
                    case Direction.Down:
                        if (!grid[x, y-1].Occupied)
                        {
                            this.y--;
                        }
                        break;
                    case Direction.Up:
                        if (!grid[x, y+1].Occupied)
                        {
                            this.y++;
                        }
                        break;
                    case Direction.Left:
                        if (!grid[x-1, y].Occupied)
                        {
                            this.x--;
                        }
                        break;
                    case Direction.Right:
                        if (!grid[x+1, y].Occupied)
                        {
                            this.x++;
                        }
                        break;
                    default:
                        Waiting?.Invoke(this);
                        break;
                }
                Moved?.Invoke(this);
            }
            else
            {
                Waiting?.Invoke(this);
            }
        }

        public bool NextIsIntersection()
        {
            switch (this.direction)
            {
                case Direction.Down:
                    if (grid[x, y-1].GetType() == typeof(IntersectionTile))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Direction.Up:
                    if (grid[x, y+1].GetType() == typeof(IntersectionTile))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Direction.Left:
                    if (grid[x-1, y].GetType() == typeof(IntersectionTile))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Direction.Right:
                    if (grid[x+1, y].GetType() == typeof(IntersectionTile))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
                    break;
            };
        }
    }
}
