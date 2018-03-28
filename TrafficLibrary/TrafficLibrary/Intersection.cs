using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics.Vectors;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    class Intersection : IEnumerable
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
            throw new NotImplementedException();
        }

        public Intersection(ISignalStrategy signal, List<Vector2> startCoords, grid)
        {
            this.signal = signal;
            this.startCoords = startCoords;
            this.grid = grid;
            random = new Random();
        }

        public void Update()
        {
            for(int i = 0; i < vehicles.Count; i++)
            {
                vehicles[i].Move(signal);
                if (vehicles[i].Direction == Direction.None)
                {
                    vehicles[i].removeFromIntersection(vehicles[i]);
                    i--;
                }
            }
            signal.Update();
        }

        public void Add(IVehicle vehicle)
        {
            Vector2 vCoords = startCoords[random.Next(startCoords.Count)];
            vehicle.X = vCoords.X;
            vehicle.Y = vCoords.Y;
        }

        private void removeFromIntersection(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
