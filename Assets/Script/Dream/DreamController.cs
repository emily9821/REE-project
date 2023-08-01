using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DreamController : MonoBehaviour
{
    public static DreamController instance; //생성

    public Dream[] dreams; //day
    //private SleepController sleepController;
    public SpriteRenderer renderer;
    public TextMeshProUGUI text;
    public GameObject textPanel;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("daydream");
        text=DialogueManager.instance.text;
        textPanel=DialogueManager.instance.dialoguePanel;
        text.text="";
        ShowAllDreams();
    }

    private void ShowAllDreams()
    {
        StartCoroutine(ShowDream());
    }

    IEnumerator ShowDream()
    {
        textPanel.SetActive(true);
        foreach (var dream in dreams)
        {
            renderer.sprite=dream.img;
            renderer.gameObject.transform.localScale= new Vector3(150,150,1);
            renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
            foreach (var _text in dream.detailDescription)
            {
                text.text=_text;
                Debug.Log(text.text);
                yield return new WaitForSeconds(dream.waitTime);
            }
        }
        text.text="";
        textPanel.SetActive(false);
        Debug.Log("Dream"+(PlayerManager.day-1));
        GameEventLinker.NewEvent("Dream"+(PlayerManager.day-1),true);
    }
}

[System.Serializable]
public class Dream
{
    public int dreamday;
    public string dreamName;
    public string[] detailDescription;
    public float waitTime;
    public Sprite img;
}