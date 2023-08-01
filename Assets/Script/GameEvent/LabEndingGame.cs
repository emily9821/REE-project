using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabEndingGame : MonoBehaviour
{
    public SpriteRenderer renderer;
    public TextMeshProUGUI text;
    public GameObject textPanel;

    private SleepController sleepController;

    void Start()
    {
        text=DialogueManager.instance.text;
        textPanel=DialogueManager.instance.dialoguePanel;
        text.text= "";
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.name == "Player"  && Input.GetKeyDown(KeyCode.Space))
        {
            if(PlayerManager.instance.enditemcount != 4)
            {
                Debug.Log("단서가 부족합니다.");
            }
            else
            {
                renderer.gameObject.SetActive(true);
                renderer.gameObject.transform.localScale= new Vector3(150,150,1);
                renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
                textPanel.SetActive(true);
                text.text="알맞은 물약을 고르시오";
                StartCoroutine(Endgame());
            }
        }
    }

    IEnumerator Endgame()
    {
        var options= EventOptionHandler.Call("medi_selection");
        options.AddEvent(() => Destroy(options.gameObject));
        yield return new WaitUntil(() => options == null);
        text.text="";
        textPanel.SetActive(false);
        Debug.Log("sleep");
        //sleepController.StartCoroutine(Sleeping());
    }

    public int happyendButton()
    {
        return 1;
    }
}