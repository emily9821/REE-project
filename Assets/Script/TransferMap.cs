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
    public bool onlock;
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
            if(!onlock && arrscenelock==null) //해금 조건이 없는 경우
            {
                /* thePlayer.currentMapName = transferMapName;
                SceneManager.LoadScene(transferMapName); */
            }
            else
            {
                foreach(var scene in arrscenelock)
                {
                    if(PlayerManager.day == scene._day) // 해금 조건이 day와 일치할 경우
                    {
                        onlock=true;
                        if(transferMapName == "veranda" && scene._day ==2)
                        {
                            if(!GameEventLinker.IsAvailable("doorlock_workspace"))
                            {
                                showtext(scene.description);
                                GameEventLinker.NewEvent("doorlock_veranda",true);
                                break;
                            }
                            onlock=false;
                        }
                        if(transferMapName == "workspace" && scene._day ==1)
                        {
                            if(!GameEventLinker.IsAvailable("doorlock_workspace"))
                            {
                                showtext(scene.description);
                                StartCoroutine(_doorLockcoroutine());
                                break;
                            } 
                            onlock=false;
                        }
                        else
                        {
                            showtext(scene.description);
                            onlock=true;
                        }
                        break;
                    }       
                }
            }
            
            if(!onlock ) //해금되면 입장
            {
                Debug.Log("transfer");
                thePlayer.currentMapName = transferMapName;
                SceneManager.LoadScene(transferMapName);
            }
        }
    }

    IEnumerator _doorLockcoroutine()
    {
        Instantiate(Resources.Load<GameObject>("Door Lock"));
        yield return new WaitUntil(()=>GameEventLinker.IsAvailable("doorlock_workspace"));
        //onlock=false;
        Debug.Log("ok");
        thePlayer.currentMapName = transferMapName;
        SceneManager.LoadScene(transferMapName);
        //Instantiate(Resources.Load<GameObject>("LabMinigame"));
    }

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
    }

}

[System.Serializable]
public class scenelock
{
    public int _day;
    public string[] description;
}


