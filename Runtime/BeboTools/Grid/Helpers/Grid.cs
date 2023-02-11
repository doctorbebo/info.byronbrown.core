using GridClass = BeboTools.Grid.Grid;
using System.Collections.Generic;
using System.Collections;

namespace BeboTools.Grid.Helpers
{
    public static class Grid
    {
        /// <summary>
        /// Determines if the x and y are valid grid coordinates
        /// </summary>
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
        public static IEnumerable<Cell> CellArea(this GridClass grid, Coordinates startCoor, Coordinates endCoor)
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
                grid[cell.Coordinates] = cell;
            }
            
            grid.FillGrid();
            grid.AssignRelativeCells();
        }
        
                
        /// <summary>
        /// Assigns relative cells for the grid.
        /// </summary>
        internal static void AssignRelativeCells(this GridClass grid)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    Cell current = grid[x, y];
                    current.NorthCell = grid.ValidCoordinates(x, y + 1) ? grid[x, y + 1] : null; 
                    current.EastCell = grid.ValidCoordinates(x + 1, y) ? grid[x + 1, y] : null;
                    current.SouthCell = grid.ValidCoordinates(x, y - 1) ? grid[x, y - 1] : null; 
                    current.WestCell = grid.ValidCoordinates(x - 1, y) ? grid[x - 1, y] : null;
                }
            }
        }
        
        /// <summary>
        /// Iterates through the grid filling each cell with a cell object if cell is null
        /// </summary>
        internal static void FillGrid(this GridClass grid)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    if (grid[x, y] == null)
                    {
                        grid[x, y] = new Cell(grid, x, y);
                    }
                }
            }
        }
    }
    
}
