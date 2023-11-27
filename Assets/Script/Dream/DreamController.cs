using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DreamController : MonoBehaviour
{
    public static DreamController instance; //생성

    public Dream[] dreams; //day
    public SpriteRenderer renderer;
    public TextMeshProUGUI text;
    public GameObject textPanel;
    //private SleepController _sleepController;

    // Start is called before the first frame update
    void Start()
    {
        //_sleepController = FindObjectOfType<SleepController>();
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
        FadeManager.StartFadeIn();
        textPanel.SetActive(true);
        foreach (var dream in dreams)
        {
            if(SoundEffect.none != dream.soundef)
               SFX.Play(dream.soundef);
    
            renderer.sprite=dream.img;
            renderer.gameObject.transform.localScale= new Vector3(150,150,1);
            renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
            //yield return new WaitForSeconds(0.1f);
            foreach (var _text in dream.detailDescription)
            {
                text.text=_text;
                //Debug.Log(text.text);
                yield return new WaitForSeconds(dream.waitTime);
            }
        }
        text.text="";
        yield return new WaitForSeconds(1f);
        textPanel.SetActive(false);
        
        if(PlayerManager.day == 0 ||(PlayerManager.day ==5 && !SleepController.isSleeping ))
        {
            //Debug.Log("Dream"+(PlayerManager.day));
            GameEventLinker.NewEvent("Dream"+(PlayerManager.day),true);
        }
        else
        {
            //Debug.Log("Dream"+(PlayerManager.day-1));
            GameEventLinker.NewEvent("Dream"+(PlayerManager.day-1),true);
        }
            
    }


}

[System.Serializable]
public class Dream
{
    public string dreamName;
    public string[] detailDescription;
    public float waitTime;
    public Sprite img;
    public SoundEffect soundef=SoundEffect.none;
}