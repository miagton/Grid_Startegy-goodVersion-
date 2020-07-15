using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager
{
    [SerializeField] LayerMask mouseInputLayerMask;
    [SerializeField] Camera mainCamera;

    private Action<Vector3> OnClickDownHandler;
    private Action<Vector3> OnClickSecondDownHandler;
    private Action OnClickSecondUpHandler;




    void Update()
    {
        GetInputPosition();
        GetPanningPosition();
    }


    private void GetInputPosition()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputLayerMask))
            {
                Vector3 inputPosition = hit.point - transform.position;
                OnClickDownHandler?.Invoke(inputPosition);// checks if event is null, if not send the messege with VEctor3 InputPosition to them


            }

        }

    }

    private void GetPanningPosition()
    {
        if (Input.GetMouseButton(1))
        {
            var position = Input.mousePosition;
            OnClickSecondDownHandler?.Invoke(position);
        }
        if (Input.GetMouseButtonUp(1))
        {
            OnClickSecondUpHandler?.Invoke();
        }
    }

    public void AddListenerOnClickDownEvent(Action<Vector3> listener)
    {
        OnClickDownHandler += listener;
    }

    public void RemoveListenerOnClickDownEvent(Action<Vector3> listener)
    {
        OnClickDownHandler -= listener;
    }
    public void AddListenerOnClickSecondDownEvent(Action<Vector3> listener)
    {
        OnClickSecondDownHandler += listener;
    }

    public void RemoveListenerOnClickSecondDownEvent(Action<Vector3> listener)
    {
        OnClickSecondDownHandler -= listener;
    }
    public void AddListenerOnClickSecondUpEvent(Action listener)
    {
        OnClickSecondUpHandler += listener;
    }

    public void RemoveListenerOnClickSecondUpEvent(Action listener)
    {
        OnClickSecondUpHandler -= listener;
    }




}
