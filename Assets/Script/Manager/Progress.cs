using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress
{
    public static string[] startScene = new string[5] { "room1", "room1", "room1", "lab", "veranda" };
    public static string[][] stageEvents = new string[5][]
    {
            new string[0] {},
            new string[5] { "doorlock_workspace", "doorlock_veranda", "room1_memo", "room1_newspaper", "workspace_noneselfie" },
            new string[9] { "doorlock_lab","lab_minigame" , "room1_pill", "room1_family", "room1_carpet", "room2_family", "room2_myth", "room2_carpet", "worspace_selfie" },
            new string[0] {},
            new string[0] {},
    };
    public static bool IsSaveDataExist { get => PlayerPrefs.GetInt("day", -1) != -1; }

    public static void Save() => PlayerPrefs.SetInt("day", PlayerManager.day);

    public static void Load() => PlayerManager.day = PlayerPrefs.GetInt("day");

    public static bool Sleep()
    {
        //if (CheckDayEvents(PlayerManager.day - 1))
        {
            PlayerManager.day++;
            Save();
            return true;
        }
        Debug.Log("Cannot sleep because of undone events");
        return false;
    }

    public static void WakeUp()
    {
        Load();
        Debug.Log("day: " + PlayerManager.day);
        SceneManager.LoadScene(startScene[PlayerManager.day - 1], LoadSceneMode.Single);
    }

    public static bool CheckDayEvents(int day)
    {
        return IsClearAllStageEvent(stageEvents[day]);
    }

    public static bool IsClearAllStageEvent(params string[] e)
    {
        for (int i = 0; i < e.Length; i++)
        {
            if (!GameEventLinker.IsAvailable(e[i]))
                return false;
        }
        return true;
    }
}