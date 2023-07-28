using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabMiniGame : MonoBehaviour
{
    // 1. 필름분리 : 카메라에서 필름을 분리하여 준비한다.
    // 2. 현상 : 필름을 준비된 현상액에 빠르게 넣고 30초간 기다린다. 이후 신속히 현상액을 버리고 다음 과정으로 넘어간다.
    // 3. 정착: 정착액을 빠르게 넣고 30초간 기다린다. 이후 신속힌 정착액을 버리고 수세과정으로 넘어간다.
    // 4. 수세: 흐르는 물에 수세한다.
    // 5. 건조: 필름을 집게로 집어 건조시킨다.

    // 책상 / 필름 - 필름을 획득하였다.
    // 책장 우측/ 현상액, 정착액 - 현상액을 획득했다 정착액을 획득했다.
    // 싱크대 / 비커 (액체 따르는 소리) - 현상할까? / 정착할까? (선택지)
    // 싱크대 왼 / 자동 수세(물소리)
    // 책상, 초록매트 - 건조할까? (선택지)

    // -> 컷씬(비밀번호 사진); 1972
    public LabPlayerDetector[] missions;
    public GameObject password;
    public string currentMissionName { get; private set; }
    public GameObject messageBox;
    public TMP_Text messageText;
    private List<string> required = new List<string>();
    private List<string> triggeredMissions = new List<string>();
    private int currentMission;

    void Start()
    {
        currentMission = 0;
        for (int i = 0; i < missions.Length; i++)
        {
            required.Add(missions[i].mission);
            missions[i].SetLabMiniGame(this);
        }
    }

    public void EnterMission(string missionName)
    {
        triggeredMissions.Insert(0, missionName);
        currentMissionName = triggeredMissions[0];
    }

    public void ExitMission(string missionName)
    {
        triggeredMissions.Remove(missionName);
        if (triggeredMissions.Count > 0)
            currentMissionName = triggeredMissions[0];
        else
            currentMissionName = null;
    }

    public bool IsBreakabe(string missionName)
    {
        return currentMission == required.IndexOf(missionName);
    }

    public void StageSuccess()
    {
        currentMission++;
        if (currentMission >= required.Count)
        {
            password.SetActive(true);
            StartCoroutine(OnSpacePressed());
        }
    }

    IEnumerator OnSpacePressed()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return null;

        password.SetActive(false);
        Destroy(gameObject);
    }
}
