using System.Collections;
using System.Collections.Generic;
using BeboTools.Grid.Helpers;

namespace BeboTools.Grid
{
    public class Grid : IEnumerable<Cell>
    {
        public Cell this[Coordinates coordinates]
        {
            get  => this[coordinates.x, coordinates.y];
            internal set => this[coordinates.x, coordinates.y] = value;
        }

        public Cell this[int x, int y]
        {
            get => CellArray[x, y];
            internal set => CellArray[x, y] = value;
        }

        public int Width => CellArray.GetLength(0);
        public int Height => CellArray.GetLength(1);
        
        internal Cell [,] CellArray;

        public Grid(int width, int height)
        {
            CellArray = new Cell[width, height];
            this.FillGrid();
            this.AssignRelativeCells();
        }

        public IEnumerator<Cell> GetEnumerator()
        { 
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    yield return CellArray[x, y];
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
    }
}