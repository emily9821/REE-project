using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// save: PlayerManager의 day -> PlayerPrefs의 day 로 저장
// load: PlayerPrefs의 day-> PlayerManager의 day 로 복사
//PlayerPrefs -> 유니티 내장 함수 (저장)

//sleep: day event 모두 완수했다면 day +1 & save
//wakeup: day에 적절한 씬 startload

public class Progress
{
    public static string[] startScene = new string[5] { "room1", "room1", "room1", "lab", "veranda" };
    public static string[][] stageEvents = new string[5][]
    {
            new string[2] { "doorlock_workspace_false", "doorlock_veranda_false"},
            new string[5] { "doorlock_workspace", "veranda_outview", "room1_memo", "room1_newspaper", "workspace_noneselfie" },
            new string[7] { "doorlock_lab","workspace_minigame" , "room1_pill", "room1_family", "room2_family", "room2_myth", "workspace_selfie" },
            new string[1] {"lab_minigame"},
            new string[0] {},
    };

    public static bool IsSaveDataExist { get => PlayerPrefs.GetInt("day", -1) != -1; }

    public static void Save() => PlayerPrefs.SetInt("day", PlayerManager.day);

    public static void Load() => PlayerManager.day = PlayerPrefs.GetInt("day");


    public static bool Sleep()
    {
        if (CheckDayEvents(PlayerManager.day - 1))
        {
            Debug.Log(PlayerManager.day);
            PlayerManager.day++;
            Save();
            return true;
        }
        Debug.Log("Cannot sleep because of undone events");
        return false;
    }

    public static void WakeUp()
    {
        Load(); //error! PlayerManager.day=2로 됨..
        Debug.Log("day: " + PlayerManager.day);
        FadeManager.StartFadeIn();
        SceneManager.LoadScene(startScene[PlayerManager.day - 1], LoadSceneMode.Single);
        //LoadSceneMode.Single : 열려있는 모든 씬 종료 후 새로 씬 로드
    }


    public static bool CheckDayEvents(int day)
    {
        Debug.Log("doorlock_workspace"+GameEventLinker.IsAvailable("doorlock_workspace"));
        Debug.Log(GameEventLinker.linkedEvent.Count);
        return IsClearAllStageEvent(stageEvents[day]);
    }

    public static bool IsClearAllStageEvent(params string[] e)
    {
        for (int i = 0; i < e.Length; i++)
        {
            if (!GameEventLinker.IsAvailable(e[i]))
            {
                Debug.Log("단서가 부족합니다:"+e[i]);
                return false;
            }
        }
        return true;
    }
}