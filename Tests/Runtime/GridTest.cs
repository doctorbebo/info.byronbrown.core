using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BeboTools.Grid;
using BeboTools.Grid.Helpers;
using UnityEngine;
using UnityEngine.TestTools;
using Grid = BeboTools.Grid.Grid;

namespace Tests.Runtime
{
    public class GridTest
    {
        private const int StartWidth = 3;
        private const int StartHeight = 4;

        private static Grid CreateDefaultGrid()
        {
            return new Grid(StartWidth, StartHeight);
        }
        
        [Test]
        public void Grid_CellArea()
        {
            Grid grid = CreateDefaultGrid();
            const int start = 1;
            const int end = 2;

            List<Cell> expectedCells = new List<Cell>()
            {
                grid[1,1],
                grid[2,1],
                grid[1,2],
                grid[2,2]
            };
            

            Vector2Int a = new Vector2Int(start, start);
            Vector2Int b = new Vector2Int(end, end);
            List<Cell> actualCellsells = grid.CellArea(a, b).ToList();

            Assert.AreEqual(expectedCells.Count, actualCellsells.Count);
            
            for (int i = 0; i < expectedCells.Count; i++)
            {
                Assert.AreSame(expectedCells[i], actualCellsells[i]);
            }
        }

        [Test]
        public void Expand_Grid()
        {
            Grid grid = CreateDefaultGrid();

            int oldWidth = grid.Width; 
            int oldHeight = grid.Height; 

            const int widthIncrease = 1;
            const int heightIncrease = 1;
                
            
            grid.Expand(widthIncrease, heightIncrease);
            
            Assert.AreEqual((widthIncrease + oldWidth) * (heightIncrease + oldHeight), grid.Count());
        }
        
        [Test]
        public void Expand_Grid_Cell_Instances_Are_Maintained()
        {
            Grid grid = CreateDefaultGrid();
            List<Cell> expectedCells = grid.ToList();
            (Vector2Int start, Vector2Int end) coor = (new Vector2Int(0, 0), new Vector2Int(StartWidth -1, StartHeight -1));
            

            const int widthIncrease = 1;
            const int heightIncrease = 1;
            grid.Expand(widthIncrease, heightIncrease);

            CollectionAssert.AreEqual(expectedCells, grid.CellArea(coor.start, coor.end));
        }

        [Test]
        public void Grid_ValidateCooridinates()
        {
            Grid grid = CreateDefaultGrid();

            Assert.IsFalse(grid.ValidCoordinates(-1, 0));
            Assert.IsFalse(grid.ValidCoordinates(0, -1));
            Assert.IsFalse(grid.ValidCoordinates(StartWidth, 0));
            Assert.IsFalse(grid.ValidCoordinates(0, StartHeight));

            for (int x = 0; x < StartWidth; x++)
            {
                for (int y = 0; y < StartHeight; y++)
                {
                    Assert.IsTrue(grid.ValidCoordinates(x, y));
                }
                
            }
        }

        [Test]
        public void Grid_GetGridRow()
        {
            Grid grid = CreateDefaultGrid();
            const int cellRowIndex = 0;
            
            List<Cell> expectedCellRow = new List<Cell>();
            for (int x = 0; x < StartWidth; x++)
            {
                expectedCellRow.Add(grid[x, cellRowIndex]);       
            }
            
            CollectionAssert.AreEqual(expectedCellRow, grid.GetRow(cellRowIndex));
        }
        
        [Test]
        public void Grid_GetGridColumn()
        {
            Grid grid = CreateDefaultGrid();
            const int cellColumnIndex = 0;
                
            List<Cell> expectedCellColmn = new List<Cell>();
            for (int y = 0; y < StartHeight; y++)
            {
                expectedCellColmn.Add(grid[cellColumnIndex, y]);       
            }
            
            CollectionAssert.AreEqual(expectedCellColmn, grid.GetColumn(cellColumnIndex));
        }
        
    }
}
