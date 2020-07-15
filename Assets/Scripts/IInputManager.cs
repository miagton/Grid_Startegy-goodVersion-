using System;
using UnityEngine;

public interface IInputManager
{
    void AddListenerOnClickDownEvent(Action<Vector3> listener);
    void AddListenerOnClickSecondDownEvent(Action<Vector3> listener);
    void AddListenerOnClickSecondUpEvent(Action listener);
    void RemoveListenerOnClickDownEvent(Action<Vector3> listener);
    void RemoveListenerOnClickSecondDownEvent(Action<Vector3> listener);
    void RemoveListenerOnClickSecondUpEvent(Action listener);
}