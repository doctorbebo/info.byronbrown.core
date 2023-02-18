using UnityEngine;

namespace BeboTools.Grid
{
    public class GridHelperComponent : MonoBehaviour
    {
        [SerializeField] private GridComponent grid;

        [Space]
        [Header("Debug Gizmos Settings")]
        [SerializeField] private bool drawGizmos = true;
        [SerializeField] private bool drawGridBoundary = true;
        [SerializeField] private bool highlightHoveredCell = true;
        [SerializeField] private bool drawPlacementCubeCellArea = true;
        [SerializeField] private bool drawPlacementCube = true;
        

        [Space]
        [Header("Debug Placement Variables")]
        [SerializeField] private Vector3 debugPlacingObjectSize = Vector3.one;

        [Space]
        [Header("Info Variables")]
        [SerializeField] private Vector3 value;
        [SerializeField] private bool mouseInsideGrid;

        [Space] 
        [Header("Hovered Cell Info")] 
        [SerializeField] private Vector2 cellGridPosition;
        [SerializeField] private Vector3 cellPositionInWorldSpace;
        
        private Vector3 cornerPost1, cornerPost2, cornerPost3, cornerPost4;
        private Cell hoveredCell;
        
        private void Start()
        {
            transform.localScale = Vector3.one;
            cornerPost1 = grid.OriginPoint;
            cornerPost2 = new Vector3(grid.OriginPoint.x, 0, grid.OriginPoint.z + grid.Length * grid.CellSize);
            cornerPost3 = grid.EndPoint;
            cornerPost4 = new Vector3(grid.OriginPoint.x + grid.Width * grid.CellSize, 0, grid.OriginPoint.z);
        }

        private void Update()
        {
            MousePosition.RoundingFactor = grid.CellSize;
            mouseInsideGrid = grid.IsInsideGrid(MousePosition.Actual);
            
            hoveredCell = grid.GetCell(MousePosition.RoundedMiddle);
            if (hoveredCell != null)
            {
                cellPositionInWorldSpace = grid.GetCellPostionInWorld(hoveredCell).GetValueOrDefault();
                cellGridPosition = hoveredCell.Position;
            }
        }

        private void OnDrawGizmos()
        {
            if(!drawGizmos || !Application.isPlaying)
                return;

            if (highlightHoveredCell && hoveredCell != null)
            {
                Gizmos.color = Color.cyan;
                Vector3 pos = cellPositionInWorldSpace + Vector3.one.Flat() * (grid.CellSize / 2);
                Gizmos.DrawWireCube(pos, new Vector3(grid.CellSize, 0, grid.CellSize));
            }

            if (drawGridBoundary)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(Vector3.Lerp(grid.EndPoint, grid.GridPos, 0.5f), new Vector3(grid.Width * grid.CellSize, 0, grid.Length * grid.CellSize));
            }
            
            CellArea area = grid.GetCellArea(MousePosition.Actual, debugPlacingObjectSize);
            if (area != null)
            {
                Vector3 pos = area.WorldMiddlePoint;

                if (drawPlacementCubeCellArea)
                {
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawWireCube(new Vector3(pos.x, 0, pos.z), new Vector3(area.WorldSize.x, 0, area.WorldSize.z));
                }

                if (drawPlacementCube)
                {
                    Gizmos.color = new Color(1f, 1f, 1, 0.5f);
                    Gizmos.DrawCube(new Vector3(pos.x, debugPlacingObjectSize.y/2 , pos.z), debugPlacingObjectSize);
                }
            }
        }
    }
}