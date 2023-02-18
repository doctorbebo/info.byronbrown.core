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

        public float CellSize => cellSize;
        public int Width => grid.Width;
        public int Length => grid.Height;
        public Vector3 GridPos => gridTransform.position;
        
        
        [SerializeField] private Transform gridTransform;
        [SerializeField] private float cellSize = 1;
        [SerializeField] private int width = 1;
        [SerializeField] private int length = 1;
        
        private Grid grid;

        private void Awake()
        {
            grid = new Grid(width, length);
            OriginPoint = GridPos.Flat();
            EndPoint = GridPos + new Vector3(width * cellSize, 0, length * cellSize );
        }

        public Vector3? GetCellPostionInWorld(Cell cell)
        {
            if (cell != null && cell.Grid == grid)
            {
                float x = cell.Position.x * cellSize + GridPos.x;
                float z = cell.Position.y * cellSize + GridPos.z;
                return new Vector3(x, 0, z);
            }
            return null;
        }

        public Cell GetCell(Vector3 pos)
        {
            Vector3 cellIndex = pos.RoundDown(cellSize) / cellSize - GridPos;
            return IsInsideGrid(pos) ? grid[(int) cellIndex.x, (int) cellIndex.z] : null;
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
            return OriginPoint.x <= pos.x && EndPoint.x >= pos.x && OriginPoint.z <= pos.z && EndPoint.z >= pos.z;
        }
    }
}