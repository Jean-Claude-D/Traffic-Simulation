using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrafficLibrary
{
    /// <summary>
    /// Grid class containing all of the information about the grid
    /// </summary>
    public class Grid
    {
        private Tile[,] tiles;

        /// <summary>
        /// Grid constructor with array of tiles
        /// </summary>
        /// <param name="tiles"></param>
        public Grid(Tile[,] tiles)
        {
            if (tiles.GetLength(0) < 4 || tiles.GetLength(1) < 4)
            {
                throw new ArgumentException("Grid must be at least 4x4 ");
            }
            if(tiles.GetLength(0) != tiles.GetLength(1))
            {
                throw new ArgumentException("Grid must be a square ");
            }
            this.tiles = tiles;
        }

        /// <summary>
        /// Indexer for the tile array
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>tiles[i,j]</returns>
        public Tile this[int i, int j]
        {
            get { return tiles[i, j]; }
            set { tiles[i, j] = value; }
        }

        /// <summary>
        /// returns the number of ti
        /// </summary>
        public int Size
        {
            get {  return tiles.GetLength(0); }
        }
        public bool IsOccupied(int x, int y)
        {
            return this[x, y].occupied;
        }
        public bool InBounds(int x, int y)
        {
            return tiles.GetLength(0) <= x && tiles.GetLength(1) <= y;
        }
    }
}
