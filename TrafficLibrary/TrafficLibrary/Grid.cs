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
            if(tiles == null)
            {
                throw new ArgumentException("Grid must not be null ");
            }
            if (tiles.GetLength(0) < 4 || tiles.GetLength(1) < 4)
            {
                throw new ArgumentException("Grid must be at least 4x4 ");
            }
            if(tiles.GetLength(0) != tiles.GetLength(1))
            {
                throw new ArgumentException("Grid must be a square");
            }
            for(int i = 0; i < tiles.GetLength(1); i++)
            {
                for(int j = 0; j < tiles.GetLength(0); j++)
                {
                    if(tiles[i,j] == null)
                    {
                        throw new ArgumentException("Grid must be filled to capacity");
                    }
                }
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
        /// returns the number of tiles
        /// </summary>
        public int Size
        {
            get {  return tiles.GetLength(0); }
        }
        public bool IsOccupied(int x, int y)
        {
            if(!InBounds(x,y))
            {
                throw new ArgumentException("Your index does not exist it is out of bounds.");
            }
            return this[x, y].Occupied;
        }
        public bool InBounds(int x, int y)
        {
            return x < tiles.GetLength(0) && y < tiles.GetLength(1);
        }
    }
}
