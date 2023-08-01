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
    public LabPlayerDetector[] missions; //미션들 모음
    public GameObject password;
    public string currentMissionName { get; private set; }
    public GameObject messageBox; //설명창 판넬
    public TMP_Text messageText;
    private List<string> required = new List<string>(); //미션 순서 리스트
    private List<string> triggeredMissions = new List<string>();
    private int currentMission; //현재 미션 단계

    void Start()
    {
        currentMission = 0;
        for (int i = 0; i < missions.Length; i++)
        {
            required.Add(missions[i].mission);  //미션 순서 정렬
            missions[i].SetLabMiniGame(this); //미션 전달
        }
    }

    public void EnterMission(string missionName)
    {
        triggeredMissions.Insert(0, missionName); //발생한 미션 삽입
        currentMissionName = triggeredMissions[0]; //현재 미션에 전달
    }

    public void ExitMission(string missionName)
    {
        triggeredMissions.Remove(missionName); //발생한 미션 삭제
        if (triggeredMissions.Count > 0) //아직 미션이 남아있을 때
            currentMissionName = triggeredMissions[0]; //현재 미션 수행
        else
            currentMissionName = null;
    }

    public bool IsBreakabe(string missionName)
    {
        return currentMission == required.IndexOf(missionName); //미션 순서 반환
    }

    public void StageSuccess()
    {
        currentMission++;
        if (currentMission >= required.Count) //전체 미션 완료
        {
            password.SetActive(true); //비번 (미션 결과) 출력
            StartCoroutine(OnSpacePressed()); //스페이스바 누르면 결과창 닫힘
        }
    }

    IEnumerator OnSpacePressed()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return null;

        password.SetActive(false);
        Destroy(gameObject);
        GameEventLinker.NewEvent("workspace_minigame",true);
    }
}
