using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BeboTools.Grid;
using BeboTools.Grid.Helpers;
using UnityEngine;
using UnityEngine.TestTools;
using Grid = BeboTools.Grid.Grid;

namespace Tests
{
    public class CellTest
    {

        private const int StartWidth = 3;
        private const int StartHeight = 4;
        

        private static Grid CreateDefaultGrid()
        {
            return new Grid(StartWidth, StartHeight);
        }

        private class TestObject
        {
            public string str;

            public TestObject(string str)
            {
                this.str = str;
            }
        }
        
        [Test]
        public void Cell_Maintains_Instance_Object()
        {
            Grid grid = CreateDefaultGrid(); 
            Vector2Int coordinates = new Vector2Int(0, 0);
            const string expectedString = "Test";
            TestObject expectedObject = new TestObject(expectedString);
            
            grid[coordinates].SetObject(expectedObject);
            TestObject actualObject = grid[coordinates].GetObject<TestObject>();
            
            Assert.AreSame(expectedObject, actualObject);
            Assert.AreEqual(expectedObject.str, actualObject.str);
        }
        
        [Test]
        public void Cell_NorthCell()
        {
            Grid grid = CreateDefaultGrid();
            
            List<Cell> expectedCell = grid.GetRow(1).ToList();
            List<Cell> actualCell = grid.GetRow(0).Select(c => c.NorthCell).ToList();
            
            CollectionAssert.AreEqual(expectedCell, actualCell);
        }
        
        [Test]
        public void Cell_EastCell()
        {
            Grid grid = CreateDefaultGrid();
            
            List<Cell> expectedCell = grid.GetColumn(1).ToList();
            List<Cell> actualCell = grid.GetColumn(0).Select(c => c.EastCell).ToList();
            
            CollectionAssert.AreEqual(expectedCell, actualCell);
        }
        
        [Test]
        public void Cell_SouthCell()
        {
            Grid grid = CreateDefaultGrid();
            
            List<Cell> expectedCell = grid.GetRow(0).ToList();
            List<Cell> actualCell = grid.GetRow(1).Select(c => c.SouthCell).ToList();
            
            CollectionAssert.AreEqual(expectedCell, actualCell);
        }
        
        [Test]
        public void Cell_WestCell()
        {
            Grid grid = CreateDefaultGrid();
            
            List<Cell> expectedCell = grid.GetColumn(0).ToList();
            List<Cell> actualCell = grid.GetColumn(1).Select(c => c.WestCell).ToList();
            
            CollectionAssert.AreEqual(expectedCell, actualCell);
        }
    }
}
