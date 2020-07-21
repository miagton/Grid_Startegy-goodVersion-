using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] StructureRepository structureRepository;
    

    [SerializeField] Button buildResidentialAreaBtn;
    [SerializeField] Button cancelBuildingBtn;
    [SerializeField] GameObject cancelBuildingPanel;
    
    [SerializeField] Button openBuildMenuBtn;
    [SerializeField] Button destroyBuildingBtn;
    [SerializeField] GameObject buildingMenuPanel;

    [SerializeField] GameObject zonesPanel;
    [SerializeField] GameObject facilitiesPanel;
    [SerializeField] GameObject roadsPanel;
    [SerializeField] Button closeBuildMenu;
   
    [SerializeField] GameObject buildButtonPrefab;


    private Action OnBuildingAreaHandler;
    private Action OnCancelActionHandler;
    private Action OnDestroyActionHandler;

    void Start()
    {
        buildingMenuPanel.SetActive(false);
        cancelBuildingPanel.SetActive(false);
       // buildResidentialAreaBtn.onClick.AddListener(OnBuildActionCallback);
        cancelBuildingBtn.onClick.AddListener(OnCancelActionCallback);
        openBuildMenuBtn.onClick.AddListener(OnOpenBuildMenu);
        destroyBuildingBtn.onClick.AddListener(OnDestroyHandler);
        closeBuildMenu.onClick.AddListener(OnCloseMenuButtonHandler);
    }

    private void OnCloseMenuButtonHandler()
    {
        buildingMenuPanel.SetActive(false);
    }

    private void OnDestroyHandler()
    {
        OnDestroyActionHandler?.Invoke();
        cancelBuildingPanel.SetActive(true);
        OnCloseMenuButtonHandler();
    }

    private void OnOpenBuildMenu()
    {
        buildingMenuPanel.SetActive(true);
        PrepareBuildMenu();
    }

    private void PrepareBuildMenu()
    {
        CreateButtonsInPanel(zonesPanel.transform,structureRepository.GetZonesNames());
        CreateButtonsInPanel(facilitiesPanel.transform,structureRepository.GetSingleStructureNames());
        CreateButtonsInPanel(roadsPanel.transform,new List<string>() { structureRepository.GetRoadStructureName() });
    }

    private void CreateButtonsInPanel(Transform panelTransform,List<string> dataToShow)
        
    {
        if (dataToShow.Count > panelTransform.childCount)
        {
            int countDifference = dataToShow.Count - panelTransform.childCount;
            for(int i = 0; i < countDifference; i++)
            {
                Instantiate(buildButtonPrefab, panelTransform);
            }
        }
        //foreach (Transform child in panelTransform)
        //{
        //    var button = child.GetComponent<Button>();
        //    if (button != null)
        //    {
        //        button.onClick.AddListener(OnBuildActionCallback);
        //    }
        //}

        for(int i = 0; i < panelTransform.childCount; i++)
        {
            var button = panelTransform.GetChild(i).GetComponent<Button>();
              if (button != null)
                {
                button.GetComponentInChildren<TextMeshProUGUI>().text = dataToShow[i];
                
                  button.onClick.AddListener(OnBuildActionCallback);
                }
        }
    }

    private void OnBuildActionCallback()
    {
        cancelBuildingPanel.SetActive(true);
        OnCloseMenuButtonHandler();
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
    public void RemoveListenerOnDestroyActionEvent(Action listener)
    {
        OnCancelActionHandler -= listener;
    }
    public void AddListenerOnDestroyActionEvent(Action listener)
    {
        OnDestroyActionHandler += listener;
    }
    public void RemoveListenerOnCancelActionEvent(Action listener)
    {
        OnDestroyActionHandler -= listener;
    }
}
