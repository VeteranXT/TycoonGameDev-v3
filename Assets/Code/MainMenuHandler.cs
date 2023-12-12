using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler  : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;
    [SerializeField] private GameObject mainMenuUI;
    public static event Action EventContinue;
    public static event Action EventLoadSavesWindow;
    public static event Action EventShowOptionsWindow;
    public static event Action EventShowCreditsWindow;
    private void Start()
    {
         GameObject.Find("").GetComponentsInChildren<Button>(buttonList);
        buttonList[0].onClick.AddListener(NewGameWindow);
        buttonList[1].onClick.AddListener(ContinueSaved);
        buttonList[2].onClick.AddListener(LoadSave);
        buttonList[3].onClick.AddListener(Options);
    }

    private void Options()
    {
        EventShowOptionsWindow?.Invoke();
        HideMainMenuUI();
    }

    private void LoadSave()
    {
        EventLoadSavesWindow?.Invoke();
        HideMainMenuUI();
        //TO DO Show Window with all save slots and handle imput
    }

    private void ContinueSaved(SavedData data)
    {
       
    }

    private void NewGameWindow()
    {
        LoadingHandler.ChangeInitialScene(SceneSorter.Warehouse);
    }
    private void HideMainMenuUI()
    {
        if (mainMenuUI != null)
        {
            mainMenuUI.SetActive(false);
        }
    }
}

