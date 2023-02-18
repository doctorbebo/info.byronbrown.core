using System.Collections;
using System.Collections.Generic;
using BeboTools.Grid.Helpers;
using UnityEngine;

namespace BeboTools.Grid
{
    public class Grid : IEnumerable<Cell>
    {
        public Cell this[Vector2Int v2]
        {
            get => this[v2.x, v2.y];
            internal set => this[v2.x, v2.y] = value;
        }

        public Cell this[int x, int y]
        {
            get
            {
                if (CellArray[x, y] == null && x < Width && y < Height)
                {
                    CellArray[x, y] = new Cell(this, x, y);
                }

                return CellArray[x, y];
            }
            internal set => CellArray[x, y] = value;
        }

        public int Width => CellArray.GetLength(0);
        public int Height => CellArray.GetLength(1);
        public int CellCount => CellArray.Length;
        
        internal Cell [,] CellArray;

        public Grid(int width, int height)
        {
            CellArray = new Cell[width, height];
        }

        public IEnumerator<Cell> GetEnumerator()
        { 
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    yield return this[x, y];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"Grid: Width: {Width} Height: {Height}";
        }

        private Cell GetCell(int x, int y)
        {
            if (x < Width && y < Height)
            {
                return CellArray[x, y] = new Cell(this, x, y);
            }
            return null;
        }
    }
}