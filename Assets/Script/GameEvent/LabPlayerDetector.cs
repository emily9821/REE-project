using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPlayerDetector : MonoBehaviour
{
    public string mission;
    public string[] indicates;

    private LabMiniGame labMiniGame;
    private bool isRunning = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (labMiniGame.currentMissionName == null)
                return;
            if (labMiniGame.currentMissionName != mission)
                return;

            if (labMiniGame.IsBreakabe(mission) && !isRunning)
            {
                StartCoroutine(MissionIndicate());
            }
        }
    }

    IEnumerator MissionIndicate()
    {
        isRunning = true;
        labMiniGame.messageBox.SetActive(true);
        for (int i = 0; i < indicates.Length; i++)
        {
            labMiniGame.messageText.text = indicates[i];
            yield return null;
            if (i == indicates.Length - 1)
                yield return new WaitForSeconds(2.5f);
            else
                yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        }
        labMiniGame.messageBox.SetActive(false);
        isRunning = false;

        var options = EventOptionHandler.Call(mission);
        options.AddEvent(() => Destroy(options.gameObject));
        yield return new WaitUntil(() => options == null);

        labMiniGame.StageSuccess();
    }

    public void SetLabMiniGame(LabMiniGame lab)
    {
        labMiniGame = lab;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            labMiniGame.EnterMission(mission);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            labMiniGame.ExitMission(mission);
        }
    }
}
