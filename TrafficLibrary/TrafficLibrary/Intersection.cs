using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public class Intersection : IEnumerable
    {
        private List<IVehicle> vehicles;
        private List<Vector2> startCoords;
        private Grid grid;
        private ISignalStrategy signal;
        private static Random random;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return vehicles.GetEnumerator();
        }

        static Intersection()
        {
            random = new Random();
        }

        public Intersection(ISignalStrategy signal, List<Vector2> startCoords, Grid grid)
        {
            this.signal = signal;
            this.startCoords = startCoords;
            this.grid = grid;
        }

        public void Update()
        {
            foreach(var v in vehicles)
            {
                v.Move(signal);
                if (v.Direction == Direction.None)
                {
                    removeFromIntersection(v);
                }
            }
            signal.Update();
        }

        public void Add(IVehicle vehicle)
        {
            vehicles.Add(vehicle);
            Vector2 vCoords;
           
            do
            {
                vCoords = startCoords[random.Next(startCoords.Count)];
            }
            while (grid.IsOccupied(vCoords.X, vCoords.Y));

            vehicle.X = vCoords.X;
            vehicle.Y = vCoords.Y;
            vehicle.Direction = grid[vehicle.X, vehicle.Y].Direction;
            vehicle.Done += removeFromIntersection(vehicle);
        }

        private void removeFromIntersection(IVehicle v)
        {
            vehicles.Remove(v);
        }
    }
}
