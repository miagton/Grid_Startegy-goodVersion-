using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager
{
    GridStructure grid;
    PlacementManager placementManager;

    public BuildingManager(PlacementManager placementManager,int cellSize,int width,int length)
    {
        this.grid = new GridStructure(cellSize, width, length);
        this.placementManager = placementManager;
    }

    public void PlaceStructureAt(Vector3 inputPosition)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(inputPosition);
        if (!grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }
    public void RemoveBuildingAtPosition(Vector3 inputPosition)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(inputPosition);
        if (grid.IsCellTaken(gridPosition))
        {
            placementManager.RemoveBuilding(gridPosition, grid);
        }
    }
}
