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
    [SerializeField] LayerMask inputLayerMask;

    private BuildingManager buildingManager;
    private int cellSize = 3;
   


    private PlayerState state;

    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildSingleStructureState;
    public PlayerRemoveBuildingState removeState;

    private void Awake()
    {
        buildingManager = new BuildingManager(placementManager, cellSize, width, length);
        removeState = new PlayerRemoveBuildingState(this, buildingManager);
        selectionState = new PlayerSelectionState(this, cameraMover);
        buildSingleStructureState = new PlayerBuildingSingleStructureState(this, buildingManager);
        state = selectionState;
#if (UNITY_EDITOR && TEST) || !(UNITY_IOS || UNITY_ANDROID)
        inputManager = this.gameObject.AddComponent<InputManager>();
#endif
#if (UNITY_IOS || UNITY_ANDROID)
        inputManager = this.gameObject.AddComponent<InputManager>();
#endif
    }
    void Start()
    {
        PrepareGameComponents();
        AssignInputListeners();
        AssignUIListeners();
    }

    private void PrepareGameComponents()
    {
        inputManager.MouseInputLayerMask = inputLayerMask;
        cameraMover.SetCameraBounds(0, width, 0, length);
    }

    private void AssignUIListeners()
    {
        uiController.AddListenerOnBuildAreaEvent(StartPlacementMode);
        uiController.AddListenerOnCancelActionEvent(CancelAction);
        uiController.AddListenerOnDestroyActionEvent(StartDestroyMode);
    }

    private void AssignInputListeners()
    {
        inputManager.AddListenerOnClickDownEvent(HandleInput);
        inputManager.AddListenerOnClickSecondDownEvent(HandleInputCameraPan);
        inputManager.AddListenerOnClickSecondUpEvent(HandleInputCameraPanStop);
        inputManager.AddListenerOnClickChangeEvent(HandleClickChange);
    }

    private void StartDestroyMode()
    {
        TransitionToState(removeState);
    }

    private void HandleClickChange(Vector3 position)
    {
        state.OnInputPointerChange(position);
    }

    private void HandleInputCameraPanStop()
    {
        state.OnInputPanUp();
    }

    private void HandleInputCameraPan(Vector3 position)
    {
        state.OnInputPanChange(position);
    }

    private void HandleInput(Vector3 position)
    {
        

        state.OnInputPointerDown(position);
    }

    private void StartPlacementMode()
    {
       
        TransitionToState(buildSingleStructureState);
    }
    private void CancelAction()
    {
       
        state.OnCancel();
    }

    public void TransitionToState(PlayerState newState)
    {
        this.state = newState;
        this.state.EnterState();
    }
}
