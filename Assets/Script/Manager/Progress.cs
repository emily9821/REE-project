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
            new string[2] { "doorlock_workspace", "doorlock_veranda"},
            new string[5] { "doorlock_workspace", "doorlock_veranda", "room1_memo", "room1_newspaper", "workspace_noneselfie" },
            new string[9] { "doorlock_lab","workspace_minigame" , "room1_pill", "room1_family", "room1_carpet", "room2_family", "room2_myth", "room2_carpet", "worspace_selfie" },
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
        Debug.Log(PlayerManager.day);
        Load(); //error! PlayerManager.day=2로 됨..
        Debug.Log(PlayerManager.day);
        Debug.Log("day: " + PlayerManager.day);
        FadeManager.StartFadeIn();
        SceneManager.LoadScene(startScene[PlayerManager.day - 1], LoadSceneMode.Single);
        //LoadSceneMode.Single : 열려있는 모든 씬 종료 후 새로 씬 로드
    }


    public static bool CheckDayEvents(int day)
    {
        return IsClearAllStageEvent(stageEvents[day]);
    }

    public static bool IsClearAllStageEvent(params string[] e)
    {
        for (int i = 0; i < e.Length; i++)
        {
            if(PlayerManager.day==1)
            {
                if (GameEventLinker.IsAvailable(e[i]))
                {
                    Debug.Log("단서가 부족합니다.");
                    return false;
                }
                    
            }
            else
            {
                if (!GameEventLinker.IsAvailable(e[i]))
                {
                    Debug.Log("단서가 부족합니다.");
                    return false;
                }
                    
            }
            
        }
        return true;
    }
}