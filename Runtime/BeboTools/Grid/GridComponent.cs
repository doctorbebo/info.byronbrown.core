using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BeboTools.Grid.Helpers;
using UnityEngine;

namespace BeboTools.Grid
{
    public class GridComponent : MonoBehaviour
    {
        public Vector3 OriginPoint { get; private set; }
        public Vector3 EndPoint { get; private set; }
        
        
        [SerializeField] private Transform gridPos;
        [SerializeField] private float cellSize = 1;
        [SerializeField] private int width = 1;
        [SerializeField] private int length = 1;

        public Transform markerOne, markerTwo, markerThree;

        private Grid grid;

        private void Awake()
        {
            grid = new Grid(width, length);
            OriginPoint = gridPos.position.Flat();
            EndPoint = gridPos.position + new Vector3(width * cellSize, 0, length * cellSize );

            markerOne.position = new Vector3(OriginPoint.x, 0, OriginPoint.z + length * cellSize);
            markerTwo.position = EndPoint;
            markerThree.position = new Vector3(OriginPoint.x + width * cellSize, 0, OriginPoint.z);

        }

        public Cell GetCell(Vector3 pos)
        {
            Vector3 cellIndex = pos.RoundDown(cellSize) / cellSize - gridPos.position;
            return IsInsideGrid(pos) ? grid[(int) cellIndex.x, (int) cellIndex.z] : null;
        }
        
        public CellArea GetCellArea(Vector3 pos, Vector3 size)
        {
            if(!IsInsideGrid(pos))
                return null;

            size = size.RoundUp(cellSize);
            Cell originCell = GetCell(pos - size / 2f + Vector3.one * (cellSize / 2f));
            Cell endCell = GetCell(pos + size / 2f - Vector3.one * (cellSize / 2f));

            if (originCell == null || endCell == null)
                return null;

            return new CellArea(grid.CellArea(originCell.Position, endCell.Position), this);
        }

        public bool IsInsideGrid(Vector3 pos)
        {
            return OriginPoint.x <= pos.x && EndPoint.x >= pos.x && OriginPoint.z <= pos.z && EndPoint.z >= pos.z;
        }
        
        
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
                float x = orginCell.Position.x * grid.cellSize + grid.gridPos.position.x;
                float z = orginCell.Position.y * grid.cellSize + grid.gridPos.position.z;
                WorldOriginPoint = new Vector3(x, 0, z);
                
                Cell endCell = Cells[Cells.Count -1];
                x = endCell.Position.x * grid.cellSize + grid.gridPos.position.x + grid.cellSize;
                z = endCell.Position.y * grid.cellSize + grid.gridPos.position.z + grid.cellSize;
                WorldEndPoint = new Vector3(x, 0, z);

                x = (endCell.Position.x * grid.cellSize + grid.cellSize) - (orginCell.Position.x * grid.cellSize);
                z = (endCell.Position.y * grid.cellSize + grid.cellSize) - (orginCell.Position.y * grid.cellSize);
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
}