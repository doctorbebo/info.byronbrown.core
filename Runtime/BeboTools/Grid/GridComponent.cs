using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BeboTools.Grid.Helpers;
using UnityEngine;

namespace BeboTools.Grid
{
    public class GridComponent : MonoBehaviour
    {
        public float CellSize => cellSize;
        public int Width => grid.Width;
        public int Length => grid.Height;

        public Vector3 StartPoint => gridTransform.position;
        public Vector3 EndPoint => StartPoint + new Vector3(width * cellSize, 0, length * cellSize );


        [SerializeField] private Transform gridTransform;
        [SerializeField] private float cellSize = 1;
        [SerializeField] private int width = 1;
        [SerializeField] private int length = 1;
        
        private Grid grid;

        private void Awake()
        {
            grid = new Grid(width, length);
        }

        public Vector3? GetCellPostionInWorld(Cell cell)
        {
            if (cell != null && cell.Grid == grid)
            {
                float x = cell.Position.x * cellSize + StartPoint.x;
                float z = cell.Position.y * cellSize + StartPoint.z;
                return new Vector3(x, 0, z);
            }
            return null;
        }

        public Cell GetCell(Vector3 pos)
        {
            if (IsInsideGrid(pos))
            {
                Vector3 cellIndex = (pos.RoundDown(cellSize) - StartPoint) / cellSize;
                return grid[(int) cellIndex.x, (int) cellIndex.z];
            }
            return null;
        }
        
        public CellArea GetCellArea(Vector3 middlePos, Vector3 size)
        {
            if(!IsInsideGrid(middlePos) || size.AllVectorsLessThan(float.Epsilon))
                return null;

            size = size.RoundUp(cellSize);
            Cell originCell = GetCell(middlePos - size / 2f + Vector3.one * (cellSize / 2f));
            Cell endCell = GetCell(middlePos + size / 2f - Vector3.one * (cellSize / 2f));

            if (originCell == null || endCell == null)
                return null;

            return new CellArea(grid.CellArea(originCell.Position, endCell.Position), this);
        }

        public bool IsInsideGrid(Vector3 pos)
        {
            return StartPoint.x <= pos.x && EndPoint.x >= pos.x && StartPoint.z <= pos.z && EndPoint.z >= pos.z;
        }
    }
}