using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLibrary
{
    public class Grid
    {
        private Tile[,] tiles;

        public Grid(Tile[,] tiles)
        {
            this.tiles = tiles;
        }

        public Tile this[int i, int j]
        {
            get { return tiles[i, j]; }
            set { tiles[i, j] = value; }
        }

        public int Size;
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
