using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingSingleStructureState : PlayerState
{
    BuildingManager buildingManager;
    public PlayerBuildingSingleStructureState(GameManager gameManager,BuildingManager buildingManager) :base(gameManager)
    {
        this.buildingManager = buildingManager;
    }
    public override void OnInputPanChange(Vector3 inputPosition)
    {
        return;
    }

    public override void OnInputPanUp()
    {
        return;
    }

    public override void OnInputPointerChange(Vector3 inputPosition)
    {
        return;
    }

    public override void OnInputPointerDown(Vector3 inputPosition)
    {
      

        buildingManager.PlaceStructureAt(inputPosition);
        
    }

    public override void OnInputPointerUp()
    {
        return;
    }

    public override void OnCancel()
    {
        this.gameManager.TransitionToState(this.gameManager.selectionState);//transition to selection state on pressing cancel button
    }
}
