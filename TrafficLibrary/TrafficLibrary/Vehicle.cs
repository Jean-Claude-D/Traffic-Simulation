using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    abstract class Vehicle : IVehicle
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
            this.emissionMoving = emissionMoving;
            this.emissionIdle = emissionIdle;
            this.passengers = passengers;
            this.grid = grid;
            this.direction = grid[x, y].Direction;
        }

        public Direction Direction
        {
            get { return this.direction; }
            private set { this.direction = value; }
        }
        public int X
        {
            get { return this.x; }
            private set { this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            private set { this.y = value; }
        }
        public int Passengers
        {
            get { return this.passengers; }
            private set { this.passengers = value; }
        }
        public double EmissionIdle
        {
            get { return this.emissionIdle; }
            private set { this.emissionIdle = value; }
        }
        public double EmissionMoving
        {
            get { return this.emissionMoving; }
            private set { this.emissionMoving = value; }
        }

        public event Handler Done;
        public event Handler Moved;
        public event Handler Waiting;

        public bool InIntersection()
        {
            if(grid[x,y].GetType == typeof(IntersectionTile))
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
            if((!NextIsIntersection()) || ((NextIsIntersection() || InIntersection()) && signal.getColour == Colour.Green))
            {
                switch (this.direction)
                {
                    case Direction.Down:
                        if (!grid[x, y--].Occupied)
                        {
                            this.y--;
                        }
                        break;
                    case Direction.Up:
                        if (!grid[x, y++].Occupied)
                        {
                            this.y++;
                        }
                        break;
                    case Direction.Left:
                        if (!grid[x--, y].Occupied)
                        {
                            this.x--;
                        }
                        break;
                    case Direction.Right:
                        if (!grid[x++, y].Occupied)
                        {
                            this.x++;
                        }
                        break;
                    default:
                        Waiting.Invoke();
                        break;
                }
                Moved?.Invoke();
            }
            else
            {
                Waiting?.Invoke();
            }
        }

        public bool NextIsIntersection()
        {
            switch (this.direction)
            {
                case Direction.Down:
                    if (grid[x, y--].GetType == typeof(IntersectionTile))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Direction.Up:
                    if (grid[x, y++].GetType == typeof(IntersectionTile))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Direction.Left:
                    if (grid[x--, y].GetType == typeof(IntersectionTile))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Direction.Right:
                    if (grid[x++, y].GetType == typeof(IntersectionTile))
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
