using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrafficLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Intersection : IEnumerable
    {
        private List<IVehicle> vehicles = new List<IVehicle>();
        private List<Vector2> startCoords;
        private Grid grid;
        private ISignalStrategy signal;
        private static Random random;

        /// <summary>
        /// Enumerates through the vehicles
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return vehicles.GetEnumerator();
        }

        /// <summary>
        /// Instantiates the random object of Intersection
        /// </summary>
        static Intersection()
        {
            random = new Random();
        }

        /// <summary>
        /// Intersection Constructor
        /// </summary>
        /// <param name="signal">Signal Strategy of the light</param>
        /// <param name="startCoords">Coordonates where vehicles can be placed</param>
        /// <param name="grid">Grid layout of the simulation</param>
        public Intersection(ISignalStrategy signal, List<Vector2> startCoords, Grid grid)
        {
            this.signal = signal;
            this.startCoords = startCoords;
            this.grid = grid;
        }

        /// <summary>
        /// Moves all the vehicles in the system
        /// </summary>
        public void Update()
        {
            for(int i = 0; i < vehicles.Count; i++)
            {
                vehicles[i].Move(signal);
            }
            signal.Update();
        }

        /// <summary>
        /// Adds new vehicles into the system.
        /// Vehicles are placed at the start of the roads randomly.
        /// </summary>
        /// <param name="vehicle"></param>
        public void Add(IVehicle vehicle)
        {
            vehicles.Add(vehicle);
            Vector2 vCoords;
           
            do
            {
                vCoords = startCoords[random.Next(startCoords.Count)];
            }
            while (grid.IsOccupied((int) vCoords.X, (int) vCoords.Y));

            vehicle.X = (int) vCoords.X;
            vehicle.Y = (int) vCoords.Y;
            vehicle.Direction = grid[vehicle.X, vehicle.Y].Direction;
            vehicle.Done += removeFromIntersection;
        }

        private void removeFromIntersection(IVehicle v)
        {
            v.Direction = Direction.None;
            
            vehicles.Remove(v);
        }
    }
}
