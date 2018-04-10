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
    /// Represents the state of all IVehicles
    /// and related Grid for a simulation
    /// </summary>
    public class Intersection : IEnumerable
    {
        /// <summary>
        /// Maximum number of attempts
        /// before aborting addition of
        /// an IVehicle in Intersection
        /// </summary>
        private const int _maxTries = 50;

        /// <summary>
        /// List of all IVehicles
        /// in this Intersection
        /// </summary>
        private List<IVehicle> _vehicles = new List<IVehicle>();

        /// <summary>
        /// List of x and y coordinates on
        /// which IVehicles are allowed to appear
        /// </summary>
        private List<Vector2> _startCoords;

        /// <summary>
        /// The layout of all Tiles
        /// in this Intersecction
        /// </summary>
        private Grid _grid;

        /// <summary>
        /// The traffic rules
        /// for this Intersection
        /// </summary>
        private ISignalStrategy _signal;

        /// <summary>
        /// Random generator used
        /// to place IVehicles
        /// </summary>
        private static Random _random;

        /// <summary>
        /// Instantiate the definition
        /// of Intersection, initializes _random
        /// </summary>
        static Intersection()
        {
            _random = new Random();
        }

        /// <summary>
        /// Iterates over _vehicles
        /// </summary>
        /// <returns>An enumerator over _vehicles</returns>
        public IEnumerator GetEnumerator()
        {
            return _vehicles.GetEnumerator();
        }

        /// <summary>
        /// Creates an Intersection with
        /// the grid layout, starting positions
        /// and traffic light rules
        /// </summary>
        /// <param name="signal">The traffic rules
        /// for this Intersection</param>
        /// <param name="startCoords">List of x and y coordinates on
        /// which IVehicles are allowed to appear</param>
        /// <param name="grid">The layout of all Tiles
        /// in this Intersecction</param>
        public Intersection(ISignalStrategy signal, List<Vector2> startCoords, Grid grid)
        {
            if(signal == null)
            {
                throw new ArgumentException("signal cannot be null");
            }
            else if(startCoords == null)
            {
                throw new ArgumentException("startCoords cannot be null");
            }
            else if(grid == null)
            {
                throw new ArgumentException("grid cannot be null");
            }

            for(int i = 0; i < startCoords.Count; i++)
            {
                if(startCoords[i] == null)
                {
                    throw new ArgumentException
                        ("startCoords[" + i + "] cannot be null," +
                        "startCoords must be filled to capacity");
                }
            }

            this._signal = signal;
            this._startCoords = startCoords;
            this._grid = grid;
        }

        /// <summary>
        /// Moves all IVehicles and
        /// update the traffic lights
        /// </summary>
        public void Update()
        {
            /* No foreach to avoid concurrent
             * modification exceptions */
            for(int i = 0; i < _vehicles.Count; i++)
            {
                _vehicles[i].Move(_signal);
            }

            _signal.Update();
        }

        /// <summary>
        /// Adds an IVehicle on a
        /// random starting coordinate
        /// </summary>
        /// <param name="vehicle">The IVehicle to
        /// add into the Intersection</param>
        /// <returns>true if the addition
        /// was succesfull, false otherwise</returns>
        public bool Add(IVehicle vehicle)
        {
            Vector2 chosenCoords;
            int tries = 0;

            do
            {
                chosenCoords = _startCoords[_random.Next(_startCoords.Count)];

                if (!_grid.IsOccupied((int)chosenCoords.X, (int)chosenCoords.Y))
                {
                    vehicle.X = (int)chosenCoords.X;
                    vehicle.Y = (int)chosenCoords.Y;
                    _grid[vehicle.X, vehicle.Y].Occupied = true;

                    vehicle.Direction = _grid[vehicle.X, vehicle.Y].Direction;
                    vehicle.Done += removeFromIntersection;

                    _vehicles.Add(vehicle);
                    return true;
                }
            }
            while (++tries <= _maxTries);

            return false;
        }

        /// <summary>
        /// Handler for Intersection on
        /// IVehicle's Done event, to remove
        /// the IVehicle from the Intersection
        /// </summary>
        /// <param name="vehicle">The Done IVehicle</param>
        private void removeFromIntersection(IVehicle vehicle)
        {
            vehicle.Direction = Direction.None;
            
            _vehicles.Remove(vehicle);
        }
    }
}
