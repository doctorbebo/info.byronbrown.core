using GridClass = BeboTools.Grid.Grid;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace BeboTools.Grid.Helpers
{
    public static class Extensions
    {
        /// <summary>
        /// Determines if the x and y are valid grid coordinates
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool ValidCoordinates(this GridClass grid, int x, int y)
        {
            return x >= 0 && x < grid.Width && y >= 0 && y < grid.Height;
        }
        
        /// <summary>
        /// Returns an IEnumerable of cells from start cell to end cell (inclusive).
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="startCoor"></param>
        /// <param name="endCoor"></param>
        /// <returns></returns>
        public static IEnumerable<Cell> CellArea(this GridClass grid, Vector2Int startCoor, Vector2Int endCoor)
        {
            Vector2Int start = new Vector2Int
            (
                startCoor.x < endCoor.x ? startCoor.x : endCoor.x,
                startCoor.y < endCoor.y ? startCoor.y : endCoor.y
            );

            Vector2Int end = new Vector2Int
            (
                startCoor.x > endCoor.x ? startCoor.x : endCoor.x,
                startCoor.y > endCoor.y ? startCoor.y : endCoor.y
            );
            
            for (int y = start.y; y <= end.y; y++)
            {
                for (int x = start.x; x <= end.x; x++)
                {
                    yield return grid[x, y];
                }
            }
        }

        /// <summary>
        /// Expands the grid while maintaining the current cells within the grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="widthIncrease"></param>
        /// <param name="heightIncrease"></param>
        public static void Expand(this GridClass grid, int widthIncrease, int heightIncrease)
        {
            widthIncrease = widthIncrease > 0 ? widthIncrease : 0;
            heightIncrease = heightIncrease > 0 ? heightIncrease : 0;

            Cell[,] oldCellArray = grid.CellArray;
            grid.CellArray = new Cell[grid.Width + widthIncrease, grid.Height + heightIncrease];

            foreach (Cell cell in oldCellArray)
            {
                if (cell != null)
                {
                    grid[cell.Position] = cell;
                }
            }
        }
        
        /// <summary>
        /// Gets the entire row of a grid
        /// <param name="rowIndex">index of the row which should be return</param> 
        /// <returns>IEnumerable of cells</returns>
        /// </summary>
        public static IEnumerable<Cell> GetRow(this GridClass grid, int rowIndex)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                yield return grid[x, rowIndex];
            }
        }
        
        /// <summary>
        /// Gets the entire column of a grid
        /// <param name="columnIndex">index of the column which should be return</param> 
        /// <returns>IEnumerable of cells</returns>
        /// </summary>
        public static IEnumerable<Cell> GetColumn(this GridClass grid, int columnIndex)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                yield return grid[columnIndex, y];
            }
        }
    }
}
