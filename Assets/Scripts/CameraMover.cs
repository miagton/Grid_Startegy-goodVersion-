using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float cameraMoveSPeed = 0.05f;

    private int cameraXMin, cameraXMax, cameraZMin, cameraZMax;//camera bounds => depends on grid size
    Vector3? basePointerPosition = null; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(Vector3 pointerPosition)
    {
        if (basePointerPosition.HasValue == false)
        {
            basePointerPosition = pointerPosition;
        }
        Vector3 newPosition = pointerPosition - basePointerPosition.Value;//getting offset=> direction in wich to pan camera
        newPosition = new Vector3(newPosition.x, 0, newPosition.y);// passing y to get proper position after converting from screen coordinates(mosue input)
        transform.Translate(newPosition * cameraMoveSPeed);
        LimitCameraMovement();
    }

    public void StopCameraMovement()
    {
        basePointerPosition = null;
    }
    public void SetCameraBounds(int cameraXMin,int cameraXMax,int cameraZMin,int cameraZMax)
    {
        this.cameraXMax = cameraXMax;
        this.cameraXMin = cameraXMin;
        this.cameraZMax = cameraZMax;
        this.cameraZMin = cameraZMin;
    }

    private void LimitCameraMovement()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraXMin, cameraXMax),
                                                   0,
                                         Mathf.Clamp(transform.position.z, cameraZMin, cameraZMax));
    }

}
