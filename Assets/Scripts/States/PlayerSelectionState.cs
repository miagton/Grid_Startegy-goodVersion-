using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionState : PlayerState
{
    CameraMover cameraMover;
    public PlayerSelectionState(GameManager gameManager,CameraMover cameraMover):base(gameManager)
    {
        this.cameraMover = cameraMover;
    }
    public override void OnInputPanChange(Vector3 inputPosition)
    {
        cameraMover.MoveCamera(inputPosition);
    }

    public override void OnInputPanUp()
    {
        cameraMover.StopCameraMovement();
    }

    public override void OnInputPointerChange(Vector3 inputPosition)
    {
        return;
    }

    public override void OnInputPointerDown(Vector3 inputPosition)
    {
        return;
    }

    public override void OnInputPointerUp()
    {
        return;
    }

    public override void OnCancel()
    {
        return;
    }
}
