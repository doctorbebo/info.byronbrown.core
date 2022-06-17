using System.Collections;
using System.Collections.Generic;
using BeboTools.Utils;
using UnityEngine;

namespace BeboTools.Grid
{
    public class Grid : IEnumerable<Cell>
    {
        public Cell this[Coordinates coordinates] => this[coordinates.x, coordinates.y];
        
        public Cell this[int x, int y] => cellArray[x, y];

        public int Width => cellArray.GetLength(0);
        public int Height => cellArray.GetLength(1);
        
        private Cell [,] cellArray;

        public Grid(int width, int height)
        {
            cellArray = new Cell[width, height];
            FillGrid();
            AssignRelativeCells();
        }
        
        /// <summary>
        /// Expands the grid while maintaining the current cells within the grid
        /// </summary>
        /// <param name="widthIncrease"></param>
        /// <param name="heightIncrease"></param>
        public void Expand(int widthIncrease, int heightIncrease)
        {
            widthIncrease = widthIncrease > 0 ? widthIncrease : 0;
            heightIncrease = heightIncrease > 0 ? heightIncrease : 0;
            
            Cell[,] newCellArray = new Cell[Width + widthIncrease, Height + heightIncrease];
            foreach (Cell cell in this)
            {
                newCellArray[cell.Coordinates.x, cell.Coordinates.y] = cell;
            }
            cellArray = newCellArray;
            FillGrid();
            AssignRelativeCells();
        }

        /// <summary>
        /// Returns an IEnumerable of cells from start cell to end cell (inclusive).
        /// </summary>
        /// <param name="startCoor"></param>
        /// <param name="endCoor"></param>
        /// <returns></returns>
        public IEnumerable<Cell> CellArea(Coordinates startCoor, Coordinates endCoor)
        {
            Coordinates start = new Coordinates
            (
                startCoor.x < endCoor.x ? startCoor.x : endCoor.x,
                startCoor.y < endCoor.y ? startCoor.y : endCoor.y
            );

            Coordinates end = new Coordinates
            (
                startCoor.x > endCoor.x ? startCoor.x : endCoor.x,
                startCoor.y > endCoor.y ? startCoor.y : endCoor.y
            );
            
            for (int y = start.y; y <= end.y; y++)
            {
                for (int x = start.x; x <= end.x; x++)
                {
                    yield return cellArray[x, y];
                }
            }
        }

        
        public IEnumerator<Cell> GetEnumerator()
        {
            return IterateGrid().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"Grid: Width: {Width} Height: {Height}";
        }
        
        /// <summary>
        /// Assigns relative cells for the grid.
        /// </summary>
        private void AssignRelativeCells()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cell current = cellArray[x, y];
                    current.NorthCell = GetCellAtIndex(x, y + 1); 
                    current.EastCell = GetCellAtIndex(x + 1, y);
                    current.SouthCell = GetCellAtIndex(x, y - 1);
                    current.WestCell = GetCellAtIndex(x -1, y);
                }
            }
        }

        /// <summary>
        /// Attempts to get the Cell at current index. Returns null on failure
        /// </summary>
        /// <param name="x">x index</param>
        /// <param name="y">y index</param>
        /// <returns></returns>
        private Cell GetCellAtIndex(int x, int y)
        {
            return ValidCoordinates(x, y) ? cellArray[x, y] : null;
        }
        
        /// <summary>
        /// Determines if the x and y are valid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool ValidCoordinates(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        /// <summary>
        /// Iterates through the grid filling each cell with a cell object if cell is null
        /// </summary>
        private void FillGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if(cellArray[x, y].IsNull())
                        cellArray[x, y] = new Cell(this, x, y);
                }
            }
        }

        /// <summary>
        /// Enumerates through each cell of the grid
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Cell> IterateGrid()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    yield return cellArray[x, y];
                }
            }
        }
    }
}