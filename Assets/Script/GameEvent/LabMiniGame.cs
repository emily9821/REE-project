using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabMiniGame : MonoBehaviour
{
    // 1. �ʸ��и� : ī�޶󿡼� �ʸ��� �и��Ͽ� �غ��Ѵ�.
    // 2. ���� : �ʸ��� �غ�� ����׿� ������ �ְ� 30�ʰ� ��ٸ���. ���� �ż��� ������� ������ ���� �������� �Ѿ��.
    // 3. ����: �������� ������ �ְ� 30�ʰ� ��ٸ���. ���� �ż��� �������� ������ ������������ �Ѿ��.
    // 4. ����: �帣�� ���� �����Ѵ�.
    // 5. ����: �ʸ��� ���Է� ���� ������Ų��.

    // å�� / �ʸ� - �ʸ��� ȹ���Ͽ���.
    // å�� ����/ �����, ������ - ������� ȹ���ߴ� �������� ȹ���ߴ�.
    // ��ũ�� / ��Ŀ (��ü ������ �Ҹ�) - �����ұ�? / �����ұ�? (������)
    // ��ũ�� �� / �ڵ� ����(���Ҹ�)
    // å��, �ʷϸ�Ʈ - �����ұ�? (������)

    // -> �ƾ�(��й�ȣ ����); 1972
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
