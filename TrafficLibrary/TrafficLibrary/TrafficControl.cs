﻿using System;
using System.Text.RegularExpressions;
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

        private static Regex singleNumber = new Regex("^[0-9]+$");
        
        /// <summary>
        /// Initializes this TrafficControl's
        /// fields from the fileContent
        /// </summary>
        /// <param name="fileContent">The String content of the file
        /// to parse for Grid and Intersection initialization</param>
        public void Parse(String fileContent)
        {
            string[] lines = fileContent.Split
                (new string[] { Environment.NewLine },
                StringSplitOptions.None);

            int totalNumVehicles;
        }

        /// <summary>
        /// Throws an ArgumentException if line does not match regex,
        /// does nothing otherwise
        /// </summary>
        /// <param name="line">The string to match</param>
        /// <param name="expectedMessage">The string describing what format
        /// line must respect</param>
        /// <param name="lineNum">The line number from the context</param>
        private static void validate(String line, Regex regex, string expectedMessage = null, int lineNum = -1)
        {
            if(!regex.IsMatch(line))
            {
                string exceptionMessage = "";

                if(lineNum >= 0)
                {
                    exceptionMessage += "Error at line " + lineNum + " :"
                        + Environment.NewLine;
                }

                exceptionMessage += line + Environment.NewLine + "Expected :"
                    + Environment.NewLine;

                if(!expectedMessage.Equals(null))
                {
                    exceptionMessage += expectedMessage;
                }
                else
                {
                    exceptionMessage += regex.ToString();
                }

                throw new ArgumentException(exceptionMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The target type of the parsing</typeparam>
        /// <param name="parse">The function parsing from string to data's target type</param>
        /// <param name="isValid">The predicate validating the actual data</param>
        /// <param name="line">The data in string format</param>
        /// <param name="conditionsMessage">The error message explaining what is
        /// expected from the data in string</param>
        /// <param name="lineNum">The line number from the context</param>
        /// <returns></returns>
        private static T parseLine<T>(Func<string, T> parse, Predicate<T> isValid, string line, string conditionsMessage = null, int lineNum = -1)
        {
            T data = parse(line);

            if(isValid(data))
            {
                return data;
            }
            else
            {
                string exceptionMessage = "";

                if (lineNum >= 0)
                {
                    exceptionMessage += "Error at line " + lineNum + " :"
                        + Environment.NewLine;
                }

                exceptionMessage += line;

                if (!conditionsMessage.Equals(null))
                {
                    exceptionMessage += Environment.NewLine +  "Error :"
                    + Environment.NewLine + conditionsMessage;
                }

                throw new ArgumentException(exceptionMessage);
            }
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
