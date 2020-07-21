using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStructure 
{
    [SerializeField] int cellSize = 3;
    Cell[,] grid;
    private int width, length;
  public GridStructure(int _cellsize,int width,int length)
  {
        this.cellSize = _cellsize;
        this.width = width;
        this.length = length;
        grid = new Cell[this.width,this.length];
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for(int column = 0; column < grid.GetLength(1); column++)
            {
                grid[row, column] = new Cell();
            }
        }
  }
    
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);

        Vector3 positionOnGrid = new Vector3(x * cellSize, 0, z * cellSize);
        return positionOnGrid;
        
    }

   

    private Vector2Int CalculateGridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)(gridPosition.x / cellSize),  (int)(gridPosition.z / cellSize));
    }

    public bool IsCellTaken(Vector3 gridPosition)
    {
        var cellIndex=CalculateGridIndex(gridPosition);
        if (CheckIndexValidation(cellIndex))//checking if this cell's index is in cell[] bounds
            return grid[cellIndex.y, cellIndex.x].IsTaken;
        else
            throw new IndexOutOfRangeException("No index " + cellIndex + " in grid");
    }

    public void PlaceStructureOnGrid(GameObject structure, Vector3 gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        if (CheckIndexValidation(cellIndex))//checking if this cell's index is in cell[] bounds
            grid[cellIndex.y, cellIndex.x].SetConstruction(structure);// adding a structure to current cell
    }

    private bool CheckIndexValidation(Vector2Int cellIndex)
    {
        if (cellIndex.x >= 0 && cellIndex.x < grid.GetLength(1) && cellIndex.y >= 0 && cellIndex.y < grid.GetLength(0))
            return true;
        else
            return false;
    }

    public GameObject GetStructureFromGrid(Vector3 gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        
        var currentObject=grid[cellIndex.y, cellIndex.x].GetStructure();// adding a structure to current cell
        return currentObject;
    }

    public void RemoveStructureFromGrid(Vector3 gridPosition)
    {
        var cellIndex = CalculateGridIndex(gridPosition);
        grid[cellIndex.y, cellIndex.x].RemoveStructure();
    }

}
