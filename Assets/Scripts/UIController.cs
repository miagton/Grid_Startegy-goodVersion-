using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button buildResidentialAreaBtn;
    [SerializeField] Button cancelBuildingBtn;
    [SerializeField] GameObject cancelBuildingPanel;

    private Action OnBuildingAreaHandler;
    private Action OnCancelActionHandler;

    void Start()
    {
        cancelBuildingPanel.SetActive(false);
        buildResidentialAreaBtn.onClick.AddListener(OnBuildActionCallback);
        cancelBuildingBtn.onClick.AddListener(OnCancelActionCallback);
    }

    private void OnBuildActionCallback()
    {
        cancelBuildingPanel.SetActive(true);
        OnBuildingAreaHandler?.Invoke();
    }

    private void OnCancelActionCallback()
    {
        cancelBuildingPanel.SetActive(false);
        OnCancelActionHandler?.Invoke();
    }
  
    public void AddListenerOnBuildAreaEvent(Action listener)
    {
        OnBuildingAreaHandler += listener;
    }
    public void RemoveListenerOnBuildAreEvent(Action listener)
    {
        OnBuildingAreaHandler -= listener;
    }

    public void AddListenerOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler += listener;
    }
    public void RemoveListenerOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler -= listener;
    }
}
