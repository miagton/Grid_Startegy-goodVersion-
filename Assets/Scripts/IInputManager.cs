using System;
using UnityEngine;

public interface IInputManager
{
    LayerMask MouseInputLayerMask { get; set; }
    void AddListenerOnClickDownEvent(Action<Vector3> listener);
    void AddListenerOnClickUpEvent(Action listener);
    void AddListenerOnClickChangeEvent(Action<Vector3> listener);
    void AddListenerOnClickSecondDownEvent(Action<Vector3> listener);
    void AddListenerOnClickSecondUpEvent(Action listener);
    void RemoveListenerOnClickDownEvent(Action<Vector3> listener);
    void RemoveListenerOnClickSecondDownEvent(Action<Vector3> listener);
    void RemoveListenerOnClickSecondUpEvent(Action listener);
    void RemoveListenerOnClickUpEvent(Action listener);
    void RemoveListenerOnClickChangeEvent(Action<Vector3> listener);
}