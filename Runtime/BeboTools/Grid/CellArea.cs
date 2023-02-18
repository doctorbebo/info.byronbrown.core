using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BeboTools.Grid
{
    public class CellArea : IEnumerable<Cell>
    {
            
        public readonly List<Cell> Cells;
        public readonly Vector3 WorldOriginPoint;
        public readonly Vector3 WorldMiddlePoint;
        public readonly Vector3 WorldEndPoint;
        public readonly Vector3 WorldSize;

        internal CellArea(IEnumerable<Cell> cells, GridComponent grid)
        {
            Cells = cells.ToList();

            Cell orginCell = Cells[0];
            float x = orginCell.Position.x * grid.CellSize + grid.GridPos.x;
            float z = orginCell.Position.y * grid.CellSize + grid.GridPos.z;
            WorldOriginPoint = new Vector3(x, 0, z);
                
            Cell endCell = Cells[Cells.Count -1];
            x = endCell.Position.x * grid.CellSize + grid.GridPos.x + grid.CellSize;
            z = endCell.Position.y * grid.CellSize + grid.GridPos.z + grid.CellSize;
            WorldEndPoint = new Vector3(x, 0, z);

            x = (endCell.Position.x * grid.CellSize + grid.CellSize) - (orginCell.Position.x * grid.CellSize);
            z = (endCell.Position.y * grid.CellSize + grid.CellSize) - (orginCell.Position.y * grid.CellSize);
            WorldSize = new Vector3(x, 0, z);

            WorldMiddlePoint = Vector3.Lerp(WorldOriginPoint, WorldEndPoint, 0.5f);
        }
            
        public IEnumerator<Cell> GetEnumerator() => Cells.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            return $"Origin: {WorldOriginPoint} End: {WorldEndPoint} Cell Count: {Cells.Count}";
        }
    }
}