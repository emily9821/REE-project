using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class TransferMap : MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름
    public scenelock[] arrscenelock; //scene 해금

    private PlayerManager thePlayer; //생성
    private FadeManager theFade;
    private OrderManager theOrder;
    public bool flag;
    public bool sclock;
    int day;

    //text
    public TextMeshProUGUI text;
    public GameObject textPanel;

    

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        //GetComponent 단일객체
        //FindObjectOfType 모든 객체
        theFade = FindObjectOfType<FadeManager>();
        theOrder= FindObjectOfType<OrderManager>();
        textPanel=DialogueManager.instance.dialoguePanel;
        // if (!textPanel.activeSelf)
        //     textPanel.SetActive(false);
        text=DialogueManager.instance.text;
        text.text="";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            if(!sclock && arrscenelock==null)
            {
                thePlayer.currentMapName = transferMapName;
                SceneManager.LoadScene(transferMapName);
            }
            else
            {
                foreach(var scene in arrscenelock)
                {
                    if(PlayerManager.day == scene._day)
                    {
                        sclock=true;
                        showtext(scene.description);
                        if(transferMapName == "workspace" && scene._day ==1) 
                        {
                            // StartCoroutine(_doorLockcoroutine());
                            if(GameEventLinker.IsAvailable("doorlock"))
                            {
                                sclock=false;
                                break;
                            }
                            Instantiate(Resources.Load<GameObject>("Door Lock"));
                            
                        }
                        break;
                    }
                    else
                        sclock=false;
                }
            }
            
            if(!sclock )
            {
                thePlayer.currentMapName = transferMapName;
                SceneManager.LoadScene(transferMapName);
            }
        }
    }

    // IEnumerator _doorLockcoroutine()
    // {
    //     yield return new WaitForSeconds(1.5f);
    //     if(GameEventLinker.IsAvailable("doorlock"))
    //     {
    //         sclock=false;
    //         break;
    //     }
    //     Instantiate(Resources.Load<GameObject>("Door Lock"));
    // }
    public void showtext(string[] sentence)
    {
        Debug.Log(gameObject.name);
        Debug.Log(DialogueManager.instance);
        Debug.Log(DialogueManager.instance.dialoguePanel);
        textPanel.SetActive(true);
        StartCoroutine(starttextCoroutine(sentence));
    }

    IEnumerator starttextCoroutine(string[] sentence)
    {
        foreach (var item in sentence)
        {
            text.text=item;
            Debug.Log(text.text);
            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        }
        textPanel.SetActive(false);
    }

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)) //esc
        // {
        //     StopAllCoroutines();
        //     textPanel.SetActive(false);
        // }
    }

}

[System.Serializable]
public class scenelock
{
    public int _day;
    public string[] description;
}


