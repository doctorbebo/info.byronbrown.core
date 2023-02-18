using System;
using System.Collections.Generic;
using UnityEngine;

namespace BeboTools.Grid
{
    public class Cell
    {
        public override string ToString()
        {
            return $"x {Position.x}, y {Position.y}";
        }

        internal readonly Dictionary<Type, object> CellObjects = new Dictionary<Type, object>();

        /// <summary>
        /// returns the grid this cell belongs to
        /// </summary>
        public Grid Grid { get; }
        
        /// <summary>
        /// X and Y Coordinates of this Cell
        /// </summary>
        public Vector2Int Position { get; }

        /// <summary>
        /// Next Cell Up or North relative to this cell
        /// </summary>
        public Cell NorthCell => Grid[Position.x, Position.y + 1];
        /// <summary>
        /// Next Cell Right or East relative to this cell
        /// </summary>
        public Cell EastCell => Grid[Position.x + 1, Position.y];
        /// <summary>
        /// Next Cell Down or South relative to this cell
        /// </summary>
        public Cell SouthCell => Grid[Position.x, Position.y - 1];
        /// <summary>
        /// Next Cell Left or West relative to this cell
        /// </summary>
        public Cell WestCell => Grid[Position.x - 1, Position.y];


        internal Cell(Grid grid, int x, int y) : this(grid, new Vector2Int(x, y)){ }
        internal Cell(Grid grid, Vector2Int position)
        {
            Position = position;
            Grid = grid;
        }
        

        public T GetObject<T>()                              
        {
            if (CellObjects.TryGetValue(typeof(T), out object value))
                return (T)value;
            else
                return default;
        }

        public void SetObject<T>(T t)
        {
            if (!CellObjects.ContainsKey(t.GetType()))
                CellObjects.Add(t.GetType(), t);
            else
                CellObjects[t.GetType()] = t;
        }
    }
}