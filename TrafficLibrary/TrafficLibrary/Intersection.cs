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
        }

        public void Update()
        {
            foreach(var v in vehicles)
            {
                v.Move(signal);
            }
            signal.Update();
        }

        public void Add(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        private void removeFromIntersection(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
