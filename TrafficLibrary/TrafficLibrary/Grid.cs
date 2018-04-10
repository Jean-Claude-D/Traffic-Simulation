using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrafficLibrary
{
    /// <summary>
    /// Represents all Tiles in the intersection
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// All Tiles contained in this Grid
        /// </summary>
        private Tile[,] _tiles;

        /// <summary>
        /// Creates a Grid from Tiles
        /// </summary>
        /// <param name="tiles">The tiles
        /// contained in this Grid</param>
        public Grid(Tile[,] tiles)
        {
            if(tiles == null)
            {
                throw new ArgumentException("tiles cannot be null");
            }
            else if (tiles.GetLength(0) != tiles.GetLength(1))
            {
                throw new ArgumentException("Grid must be a square");
            }
            else if (tiles.GetLength(0) < 4)
            {
                throw new ArgumentException("Grid must be at least 4x4");
            }

            for(int i = 0; i < tiles.GetLength(1); i++)
            {
                for(int j = 0; j < tiles.GetLength(0); j++)
                {
                    if(tiles[i,j] == null)
                    {
                        throw new ArgumentException
                            ("Tile [" + i + ", " + j +
                            "] cannot be null, Grid must be filled to capacity");
                    }
                }
            }

            _tiles = tiles;
        }

        /// <summary>
        /// Indexer for the Tile array
        /// </summary>
        /// <param name="i">Column index</param>
        /// <param name="j">Row index</param>
        /// <returns>The Tile at column i, row j</returns>
        public Tile this[int i, int j]
        {
            get { return _tiles[i, j]; }
            set { _tiles[i, j] = value; }
        }

        /// <summary>
        /// Length of of each
        /// side of the Grid
        /// </summary>
        public int Size
        {
            get {  return _tiles.GetLength(0); }
        }

        /// <summary>
        /// Checks if the Tile at x and y
        /// is occupied by an IVehicle
        /// </summary>
        /// <param name="x">Column index</param>
        /// <param name="y">Row index</param>
        /// <returns>The Occupied field of Tile at x and y</returns>
        public bool IsOccupied(int x, int y)
        {
            if(!InBounds(x,y))
            {
                throw new ArgumentException("Cannot check [" + x + ", " + y + "], out of bounds");
            }

            return this[x, y].Occupied;
        }

        /// <summary>
        /// Checks if the given x and y
        /// are in bounds of this Grid
        /// </summary>
        /// <param name="x">Column index</param>
        /// <param name="y">Row index</param>
        /// <returns>true if both x and y are
        /// smaller than this Grid's Size</returns>
        public bool InBounds(int x, int y)
        {
            return x < Size && y < Size && x >= 0 && y >= 0;
        }
    }
}
