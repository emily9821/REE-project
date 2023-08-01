using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPlayerDetector : MonoBehaviour
{
    public string mission; //미션 이름
    public string[] indicates; //미션 설명

    private LabMiniGame labMiniGame;
    private bool isRunning = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (labMiniGame.currentMissionName == null) //미션이 없을때 
                return;
            if (labMiniGame.currentMissionName != mission) //미션이 일치하지 않을때 
                return;

            if (labMiniGame.IsBreakabe(mission) && !isRunning) //미션 일치 & 아직 미완료 경우
            {
                StartCoroutine(MissionIndicate());
            }
        }
    }

    IEnumerator MissionIndicate()
    {
        isRunning = true;//미션 수행중
        labMiniGame.messageBox.SetActive(true); //설명창 true
        for (int i = 0; i < indicates.Length; i++) //설명 출력
        {
            labMiniGame.messageText.text = indicates[i];
            yield return null;
            if (i == indicates.Length - 1) //설명 끝날때
                yield return new WaitForSeconds(2.5f);
            else//설명 중 스페이스바로 넘김
                yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        }
        labMiniGame.messageBox.SetActive(false); //설명 닫음
        isRunning = false; //미션 끝

        var options = EventOptionHandler.Call(mission); //미션 불러옴
        options.AddEvent(() => Destroy(options.gameObject)); //미션 닫음 추가
        yield return new WaitUntil(() => options == null); //미션 끝날 때 까지

        labMiniGame.StageSuccess(); //미션 결과
    }

    public void SetLabMiniGame(LabMiniGame lab)
    {
        labMiniGame = lab;
    }

    private void OnTriggerEnter2D(Collider2D collision) //미션 발생 시작
    {
        if (collision.CompareTag("Player"))
        {
            labMiniGame.EnterMission(mission);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //미션 완료 후 나올때
    {
        if (collision.CompareTag("Player"))
        {
            labMiniGame.ExitMission(mission);
        }
    }
}
