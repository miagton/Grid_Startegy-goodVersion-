using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] IInputManager inputManager;
    [SerializeField] PlacementManager placementManager;
    [SerializeField] UIController uiController;
    [SerializeField] CameraMover cameraMover;
    [SerializeField] int width, length;

    private GridStructure grid;
    private int cellSize = 3;
    private bool IsBuildingModeActive = false;
    void Start()
    {
        cameraMover.SetCameraBounds(0, width, 0, length);
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        grid = new GridStructure(cellSize,width,length);
        inputManager.AddListenerOnClickDownEvent(HandleInput);
        inputManager.AddListenerOnClickSecondDownEvent(HandleInputCameraPan);
        inputManager.AddListenerOnClickSecondUpEvent(HandleInputCameraPanStop);
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancelActionEvent(CancelAction);
    }

    private void HandleInputCameraPanStop()
    {
        cameraMover.StopCameraMovement();
    }

    private void HandleInputCameraPan(Vector3 position)
    {
        if (IsBuildingModeActive == false)
        {
            cameraMover.MoveCamera(position);
        }
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (IsBuildingModeActive && grid.IsCellTaken(gridPosition) == false)//checking if cell is already taken
        {
          placementManager.CreateBuilding(gridPosition,grid);
          
        }
    }

    private void StartPlacementMode()
    {
        IsBuildingModeActive = true;
    }
    private void CancelAction()
    {
        IsBuildingModeActive = false;
    }
}
