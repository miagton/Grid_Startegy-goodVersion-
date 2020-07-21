using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IInputManager
{
    [SerializeField] Camera mainCamera;

    private Action<Vector3> OnClickDownHandler;
    private Action OnClickUpHandler;
    private Action<Vector3> OnClickChangeHandler;

    private Action<Vector3> OnClickSecondDownHandler;
    private Action OnClickSecondUpHandler;

    private LayerMask mouseInputLayerMask;
    public LayerMask MouseInputLayerMask { get => mouseInputLayerMask; set => mouseInputLayerMask=value; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        GetInputPosition();
        GetPanningPosition();
    }


    private void GetInputPosition()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CallActionOnClick((inputPosition)=> OnClickDownHandler?.Invoke(inputPosition));


        }
        if (Input.GetMouseButton(0))
        {
            CallActionOnClick((inputPosition) => OnClickChangeHandler?.Invoke(inputPosition));

        }
        if (Input.GetMouseButtonUp(0))
        {
            OnClickUpHandler?.Invoke();
        }

    }


    private void CallActionOnClick(Action<Vector3> action)
    {
        Vector3? inputPosition = GetMousePosition();
        if (inputPosition.HasValue)
        {
            // action?.Invoke(inputPosition.Value);// checks if event is null, if not send the messege with VEctor3 InputPosition to them
            action(inputPosition.Value);
            inputPosition = null;
        }
    }
    private Vector3? GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3? inputPosition = null;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputLayerMask))
        {
            inputPosition = hit.point - transform.position;


        }

        return inputPosition;
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

    public void AddListenerOnClickUpEvent(Action listener)
    {
        OnClickUpHandler += listener;
    }

    public void AddListenerOnClickChangeEvent(Action<Vector3> listener)
    {
        OnClickChangeHandler += listener;
    }

    public void RemoveListenerOnClickUpEvent(Action listener)
    {
        OnClickUpHandler -= listener;
    }

    public void RemoveListenerOnClickChangeEvent(Action<Vector3> listener)
    {
        OnClickChangeHandler -= listener;
    }
}
