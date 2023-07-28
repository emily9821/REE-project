using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public string firstScene;
    public Button load;
    public GameObject settingPanel;

    void Start()
    {
        load.interactable = IsLoadable();    
    }

    public void StartFirstScene()
    {
        PlayerManager.day = 1;
        SceneManager.LoadScene(firstScene);
    }

    public void LoadGame()
    {
        Progress.WakeUp();
    }

    public void ShowSetting()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private bool IsLoadable()
    {
        return Progress.IsSaveDataExist;
    }
}
