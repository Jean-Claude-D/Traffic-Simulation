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
            }
            else
            {
                throw new ArgumentException("Null Grid!");
            }
        }

        public Vehicle(double emissionMoving, double emissionIdle, int passengers, Grid grid, int x, int y)
        {
             if (grid != null)
            {
                this.emissionMoving = emissionMoving;
                this.emissionIdle = emissionIdle;
                this.passengers = passengers;
                this.grid = grid;
                this.x = x;
                this.y = y;
                this.direction = grid[x, y].Direction;
            }
            else
            {
                throw new ArgumentException("Null Grid!");
            }
        }

        public Direction Direction
        {
            get { return this.direction; }
            set { this.direction = value; }
        }
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
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
            if(grid[x,y].GetType().Equals(typeof(IntersectionTile)))
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
            if((!NextIsIntersection()) || InIntersection() || signal.GetColour(this.direction) == Colour.Green)
            {
                switch (this.direction)
                {
                    case Direction.Down:
                        if (y + 1 < grid.Size)
                        {
                            Done?.Invoke(this);
                            break;
                        }
                        else if(!grid[x, y + 1].Occupied)
                        {
                            this.y++;
                            grid[x, y].Occupied = true;
                            grid[x, y - 1].Occupied = false;
                        }
                        else
                        {
                            Waiting?.Invoke(this);
                        }
                        break;
                    case Direction.Up:
                        if (y - 1 >= 0)
                        {
                            Done?.Invoke(this);
                            break;
                        }
                        else if(!grid[x, y - 1].Occupied)
                        {
                            this.y--;
                            grid[x, y].Occupied = true;
                            grid[x, y + 1].Occupied = false;
                        }
                        else
                        {
                            Waiting?.Invoke(this);
                        }
                        break;
                    case Direction.Left:
                        if (x - 1 >= 0)
                        {
                            Done?.Invoke(this);
                            break;
                        }
                        else if(!grid[x - 1, y].Occupied)
                        {
                            this.x--;
                            grid[x, y].Occupied = true;
                            grid[x + 1, y].Occupied = false;
                        }
                        else
                        {
                            Waiting?.Invoke(this);
                        }
                        break;
                    case Direction.Right:
                        if (x + 1 < grid.Size)
                        {
                            Done?.Invoke(this);
                        }
                        else if(!grid[x + 1, y].Occupied)
                        {
                            this.x++;
                            grid[x, y].Occupied = true;
                            grid[x - 1, y].Occupied = false;
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
                    if(y + 1 < grid.Size)
                    {
                        return false;
                    }
                    else if (grid[x, y+1].GetType().Equals(typeof(IntersectionTile)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Direction.Up:
                    if (y - 1 >= 0)
                    {
                        return false;
                    }
                    else if (grid[x, y-1].GetType().Equals(typeof(IntersectionTile)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Direction.Left:
                    if (x - 1 >= 0)
                    {
                        return false;
                    }
                    else if (grid[x-1, y].GetType().Equals(typeof(IntersectionTile)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Direction.Right:
                    if (x + 1 < grid.Size)
                    {
                        return false;
                    }
                    else if (grid[x+1, y].GetType().Equals(typeof(IntersectionTile)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            };
        }
    }
}
