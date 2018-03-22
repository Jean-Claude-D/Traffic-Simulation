using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    class TrafficControl
    {
        /// <summary>
        /// The Random used to generate
        /// consistently random numbers
        /// </summary>
        private static Random _random;
        /// <summary>
        /// Instantiates the definition of TrafficControl,
        /// used to initialize the _random field
        /// </summary>
        static TrafficControl()
        {
            _random = new Random();
        }
        
        /// <summary>
        /// The total number of IVehicle in this simulation
        /// </summary>
        private int _numVehicles;
        /// <summary>
        /// Percentage of Car compared to
        /// other IVehicle implementations in this simulation
        /// </summary>
        private double _percentCar;
        /// <summary>
        /// Percentage of Electric compared to
        /// other IVehicle implementations in this simulation
        /// </summary>
        private double _percentElectric;

        /// <summary>
        /// The Intersection representing
        /// the state of this simulation
        /// </summary>
        public Intersection Intersection
        {
            get;
            private set;
        }
        /// <summary>
        /// The Grid representing the
        /// state of this simulation's Tiles
        /// </summary>
        public Grid Grid
        {
            get;
            private set;
        }
        /// <summary>
        /// The Total representing statistics
        /// pertaining to this simulation
        /// </summary>
        public Total Total
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new empty TrafficControl object
        /// </summary>
        public TrafficControl()
        {

        }
        
        /// <summary>
        /// Initializes this TrafficControl's
        /// fields from the fileContent
        /// </summary>
        /// <param name="fileContent">The String content of the file
        /// to parse for Grid and Intersection initialization</param>
        public void Parse(String fileContent)
        {

        }
        
        /// <summary>
        /// Updates this simulation, run at
        /// every tick of the program loop
        /// </summary>
        public void Update()
        {
            
        }
    }
}
