using System;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    /// <summary>
    /// Main Class in charge of
    /// initializing the simulation
    /// </summary>
    public class TrafficControl
    {
        /// <summary>
        /// The Random used to generate
        /// consistently random numbers
        /// </summary>
        private static Random _random;
        /// <summary>
        /// Generates a random bool value
        /// from _random
        /// </summary>
        /// <returns>Randomly true or false</returns>
        private static bool randBool()
        {
            return _random.Next(2) == 0;
        }

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
        /// The maximum number of IVehicle this
        /// simulation should ever contain
        /// </summary>
        private int _maxVehicles;

        /// <summary>
        /// The target percentage of Car compared to
        /// other IVehicle implementations in this simulation
        /// </summary>
        private double _percentCar;
        /// <summary>
        /// The actual number of Car compared to
        /// other IVehicle implementations in this simulation
        /// </summary>
        private int _carCount;

        /// <summary>
        /// The target percentage of Electric compared to
        /// other IVehicle implementations in this simulation
        /// </summary>
        private double _percentElectric;
        /// <summary>
        /// The actual percentage of Electric compared to
        /// other IVehicle implementations in this simulation
        /// </summary>
        private double _electricCount;

        /// <summary>
        /// The counter for Update to update contained
        /// objects at every "_delay" call
        /// </summary>
        private int _delayCounter;
        /// <summary>
        /// The number of calls to Update it takes
        /// for update to take place
        /// </summary>
        private int _delay;
        /// <summary>
        /// The minimum delay allowed in Parse
        /// </summary>
        private static int _minDelay = 2;
        /// <summary>
        /// The maximum delay allowed in Parse
        /// </summary>
        private static int _maxDelay = 10;

        /// <summary>
        /// The vald characters representing Tile objects
        /// in the string to parse
        /// </summary>
        private static string _validTileChars = "GURDLI1234";

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
        { }

        /// <summary>
        /// The regular expression for a single integer
        /// in a string (the integer can be up to 9 digits)
        /// </summary>
        private static Regex _singleInteger = new Regex(@"^[0-9]{1,9}\s*$");
        /// <summary>
        /// The regular expression for 1 or many integers
        /// in a string (the integer can be up to 9 digits)
        /// </summary>
        private static Regex _multipleIntegers = new Regex(@"^(?:[0-9]{1,9}\s+)*(?:[0-9]{1,9})\s*$");
        /// <summary>
        /// The regular expression for 1 or many 'Tile character'
        /// in a string (refer to _validTileChars)
        /// </summary>
        private static Regex _multipleWhiteSpacedTiles =
            new Regex(@"^(?i:[" + _validTileChars + @"]\s+)*(?i:[" + _validTileChars + @"])\s*$");

        /// <summary>
        /// Initializes this TrafficControl's
        /// fields from the fileContent
        /// </summary>
        /// <param name="fileContent">The String content of the file
        /// to parse for Grid and Intersection initialization</param>
        public void Parse(String fileContent)
        {
            string[] lines = fileContent.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None);

            /* Validate then Parse the total number of vehicles */
            validate(
                lines[0],
                _singleInteger,
                "A single positive numerical integer",
                0);
            int totalNumVehicles = parseLine<int>(
                (line) => int.Parse(line),
                (num) => num > 0,
                lines[0],
                0);

            /* Validate then Parse the delay */
            validate(
                lines[1],
                _singleInteger,
                "A single positive numerical integer",
                1);
            int delay = parseLine<int>(
                (line) => int.Parse(line),
                (givenDelay) => givenDelay >= _minDelay && givenDelay <= _maxDelay,
                lines[1],
                1);

            /* Validate then Parse the percentage of cars */
            validate(
                lines[2],
                _singleInteger,
                "A single positive numerical integer",
                2);
            int carPercent = parseLine<int>(
                (line) => int.Parse(line),
                (percent) => percent >= 0 && percent <= 100,
                lines[2],
                2);

            /* Validate then Parse the percentage of electrics */
            validate(
                lines[3],
                _singleInteger,
                "A single positive numerical integer",
                3);
            int electricPercent = parseLine<int>(
                (line) => int.Parse(line),
                (percent) => percent >= 0 && percent <= 100,
                lines[3],
                3);

            /* Validate then Parse the light timings */
            validate(
                lines[4],
                _multipleIntegers,
                "multiple positive numerical integers",
                4);
            int[] timings = parseLine<int[]>(
                (line) =>
                {
                    string[] numsStr = line.Split(
                        new char[] { ' ', '\t' },
                        StringSplitOptions.RemoveEmptyEntries);

                    int[] nums = new int[numsStr.Length];
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = int.Parse(numsStr[i]);
                    }

                    return nums;
                },
                (nums) => nums.All((num) => num > 0) && nums.Length == 4,
                lines[4],
                4);
            ISignalStrategy trafficLight = new FixedSignal(timings);

            Tile[,] grid;
            {
                /* Validate then Parse the first Tile line */
                validate(
                    lines[5],
                    _multipleWhiteSpacedTiles,
                    "multiple white-space spaced characters (0-9 or A-Z)",
                    5);
                Tile[] firstRow = parseLine<Tile[]>(
                    (line) =>
                    {
                        string[] tilesStr = line.Split(
                            new char[] { ' ', '\t' },
                            StringSplitOptions.RemoveEmptyEntries);

                        Tile[] tiles = new Tile[tilesStr.Length];
                        for (int i = 0; i < tiles.Length; i++)
                        {
                            tiles[i] = createTile(tilesStr[i], trafficLight);
                        }

                        return tiles;
                    },
                    (tileArr) => true,
                    lines[5],
                    5);

                /* Grid must be square */
                if (firstRow.Length != lines.Length - 5)
                {
                    throw new ArgumentException
                        ("Error at line :" + Environment.NewLine +
                        "5" + Environment.NewLine +
                        "Expected :" + Environment.NewLine +
                        "Grid of Tile must be square");
                }

                /* Add the first Tile line to the grid */
                grid = new Tile[firstRow.Length, lines.Length - 5];
                for (int i = 0; i < firstRow.Length; i++)
                {
                    grid[i, 0] = firstRow[i];
                }
            }

            /* Validate then Parse each grid horizontal line */
            for (int i = 6; i < lines.Length; i++)
            {
                validate(
                    lines[i],
                    _multipleWhiteSpacedTiles,
                    "multiple white-space spaced characters (0-9 or A-Z)",
                    i);

                Tile[] tileRow = parseLine<Tile[]>(
                    (line) =>
                    {
                        string[] tilesStr = line.Split(
                            new char[] { ' ', '\t' },
                            StringSplitOptions.RemoveEmptyEntries);

                        Tile[] tiles = new Tile[tilesStr.Length];
                        for (int j = 0; j < tiles.Length; j++)
                        {
                            tiles[j] = createTile(tilesStr[j], trafficLight);
                        }

                        return tiles;
                    },
                    (tileArr) => true,
                    lines[i],
                    i);

                /* All lines must have the same length */
                if (tileRow.Length != lines.Length - 5)
                {
                    throw new ArgumentException
                        ("Error at line :" + Environment.NewLine +
                        i + Environment.NewLine +
                        "Expected :" + Environment.NewLine +
                        "Grid of Tile must be square");
                }

                /* Add the Tile line to the grid */
                for (int j = 0; j < tileRow.Length; j++)
                {
                    grid[j, i - 5] = tileRow[j];
                }
            }

            Grid = new Grid(grid);

            /* Instantiate entry points to be used by Intersection */
            List<Vector2> entryPoints = new List<Vector2>();
            for (int i = 0; i < Grid.Size; i++)
            {
                for (int j = 0; j < Grid.Size; j++)
                {
                    Direction currTileDir = Grid[j, i].Direction;
                    if ((currTileDir == Direction.Up && i == (Grid.Size - 1)) ||
                        (currTileDir == Direction.Right && j == 0) ||
                        (currTileDir == Direction.Down && i == 0) ||
                        (currTileDir == Direction.Left && j == (Grid.Size - 1)))
                    {
                        entryPoints.Add(new Vector2(j, i));
                    }
                }
            }

            foreach(Vector2 v in entryPoints)
            {
                Console.WriteLine(v);
            }

            Total = new Total();
            Intersection = new Intersection(trafficLight, entryPoints, Grid);

            _delay = delay;
            _delayCounter = 0;

            _maxVehicles = totalNumVehicles;
            _numVehicles = 0;

            _percentCar = carPercent;
            _carCount = 0;

            _percentElectric = electricPercent;
            _electricCount = 0;
        }

        /// <summary>
        /// Instantiate the appropriate Tile depending on tileId
        /// </summary>
        /// <param name="tileId">The character representing the Tile to be created</param>
        /// <param name="trafficLight">The ISignalStrategy governing Light Tiles</param>
        /// <returns></returns>
        private static Tile createTile(string tileId, ISignalStrategy trafficLight)
        {
            char tileIdChar = tileId[0];
            switch (tileIdChar)
            {
                case 'G':
                    return new Grass();
                case 'U':
                    return new Road(Direction.Up);
                case 'R':
                    return new Road(Direction.Right);
                case 'D':
                    return new Road(Direction.Down);
                case 'L':
                    return new Road(Direction.Left);
                case 'I':
                    return new IntersectionTile();
                case '1':
                    return new Light(trafficLight, Direction.Down);
                case '2':
                    return new Light(trafficLight, Direction.Left);
                case '3':
                    return new Light(trafficLight, Direction.Right);
                case '4':
                    return new Light(trafficLight, Direction.Up);
                default:
                    throw new ArgumentException("Cannot create tile \'"
                        + tileId + "\', must be one of :" +
                       Environment.NewLine + _validTileChars);
            }
        }

        /// <summary>
        /// Parses the given line with parse and
        /// validates the parsed data with isValid
        /// throws an ArgumentException if parsing of validation fails
        /// </summary>
        /// <typeparam name="T">The target type of the parsing</typeparam>
        /// <param name="parse">The function parsing from string to data's target type</param>
        /// <param name="isValid">The predicate validating the actual data</param>
        /// <param name="line">The data in string format</param>
        /// <param name="conditionsMessage">The error message explaining what is
        /// expected from the data in string</param>
        /// <param name="lineNum">The line number from the context</param>
        /// <returns>The parsed and validates line</returns>
        private static T parseLine<T>(Func<string, T> parse, Predicate<T> isValid, string line, int lineNum = -1, string conditionsMessage = null)
        {
            T data = default(T);
            try
            {
                data = parse(line);
            }
            catch (Exception exc)
            {
                throw new ArgumentException
                    (conditionsMessage + ":" + Environment.NewLine, exc);
            }

            if (isValid(data))
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
                    exceptionMessage += Environment.NewLine + "Error :"
                    + Environment.NewLine + conditionsMessage;
                }

                throw new ArgumentException(exceptionMessage);
            }
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
        /// Updates this simulation, run at
        /// every tick of the program loop
        /// </summary>
        public void Update()
        {
            if (++_delayCounter >= _delay)
            {
                _delayCounter = 0;
                if (_numVehicles < _maxVehicles)
                {
                    IVehicle newIVehicle;

                    if ((_numVehicles / (double)_carCount) - _percentCar < 0.005)
                    {
                        if (randBool())
                        {
                            newIVehicle = createCar();
                        }
                        else
                        {
                            newIVehicle = createMotorcycle();
                        }
                    }
                    else if ((_numVehicles / (double)_carCount) > _percentCar)
                    {
                        newIVehicle = createMotorcycle();
                    }
                    else
                    {
                        newIVehicle = createCar();
                    }


                    if (((_numVehicles / (double)_electricCount) - _percentElectric) < 0.005)
                    {
                        if (randBool())
                        {
                            newIVehicle = createElectric(newIVehicle);
                        }
                    }
                    else if ((_numVehicles / (double)_electricCount) < _percentElectric)
                    {
                        newIVehicle = createElectric(newIVehicle);
                    }

                    newIVehicle.Moved += Total.Moved;
                    newIVehicle.Waiting += Total.Waiting;
                    newIVehicle.Done += Total.VehicleOver;
                    newIVehicle.Done += (doneVehicle) => _numVehicles--;


                    Intersection.Add(newIVehicle);
                }

                Intersection.Update();
            }
        }

        /// <summary>
        /// Create a new Car object,
        /// also updates TrafficControl's counters
        /// </summary>
        /// <returns>a new Car with this TrafficControl's Grid</returns>
        private Car createCar()
        {
            _numVehicles++;
            _carCount++;
            return new Car(Grid);
        }

        /// <summary>
        /// Create a new Motorcycle object,
        /// also updates TrafficControl's counters
        /// </summary>
        /// <returns>a new Motorcycle with this TrafficControl's Grid</returns>
        private Motorcycle createMotorcycle()
        {
            _numVehicles++;
            return new Motorcycle(Grid);
        }

        /// <summary>
        /// Decorates an IVehicle with Electric,
        /// also updates TrafficControl's counter
        /// </summary>
        /// <param name="toDecorate">The IVehicle to make Electric</param>
        /// <returns>The IVehicle toDecorate as an Electric</returns>
        private Electric createElectric(IVehicle toDecorate)
        {
            _electricCount++;
            return new Electric(toDecorate);
        }
    }
}
