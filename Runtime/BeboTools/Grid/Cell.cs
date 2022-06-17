using System;
using System.Collections.Generic;

namespace BeboTools.Grid
{
    public class Cell
    {
        public override string ToString()
        {
            return $"x {Coordinates.x}, y {Coordinates.y}";
        }

        internal readonly Dictionary<Type, object> CellObjects = new Dictionary<Type, object>();

        /// <summary>
        /// returns the grid this cell belongs to
        /// </summary>
        public Grid Grid { get; }
        
        /// <summary>
        /// X and Y Coordinates of this Cell
        /// </summary>
        public Coordinates Coordinates { get; }
        
        /// <summary>
        /// Next Cell Up or North relative to this cell
        /// </summary>
        public Cell NorthCell { get; internal set; }
        /// <summary>
        /// Next Cell Right or East relative to this cell
        /// </summary>
        public Cell EastCell { get; internal set; }
        /// <summary>
        /// Next Cell Down or South relative to this cell
        /// </summary>
        public Cell SouthCell { get; internal set; }
        /// <summary>
        /// Next Cell Left or West relative to this cell
        /// </summary>
        public Cell WestCell { get; internal set; }


        internal Cell(Grid grid, int x, int y) : this(grid, new Coordinates(x, y)){ }
        internal Cell(Grid grid, Coordinates coordinates)
        {
            Coordinates = coordinates;
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