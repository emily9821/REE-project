using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//해금
//GameEventLinker.IsAvailable("day2"); //day2 이벤트 등록 - 해금하는 시점 => true
//1. 파라미터,매개변수 모두 voidGameEventLinker.IsAvailable("day2",showText); //day2 이벤트 함수() 실행
//2. if(GameEventLinker.IsAvailable("day2"))
public class ClueManager : MonoBehaviour
{
    public static ClueManager instance; //생성

    #region Singleton
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            
        }
    }
    #endregion Singleton

    public GameObject obj;
    private string imgname;
    private SceneItemManager sceneitemmanager;

    public bool isclue=false;
    Sprite imgObject;
    public SpriteRenderer renderer;

    public TextMeshProUGUI text;
    public GameObject textPanel;
    private List<string> listSentences;
    // private int count=0;

    void Start()
    {
        Instantiate(Resources.Load<GameObject>("Item_Prefab"));
        sceneitemmanager=FindObjectOfType<SceneItemManager>();
        text.text= "";
        listSentences= new List<string>();
    }


    public int showimage(int _day,GameObject scanObj)
    {
        Debug.Log(_day);
        Debug.Log(scanObj);
        //이미지 로드
        renderer.sprite=Item_Prefab.ITEM[_day][scanObj.name].img;

        if (renderer.sprite == null)
        {
            isclue = false;
            return 0;
        }
        else
        {
            //이미지 보여주기
            renderer.gameObject.transform.localScale= new Vector3(150,150,1);
            renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
            Debug.Log(scanObj.name);
            showText(_day, scanObj);
            isclue = false;
            return 1;
        }
    }

    public void showText(int _day,GameObject scanObj)
    {
        textPanel.SetActive(true);
        foreach (var item in Item_Prefab.ITEM[_day][scanObj.name].description)
        {
            listSentences.Add(item);
            Debug.Log(listSentences);
        }

        StartCoroutine(starttextCoroutine());
        
    }
    
    IEnumerator starttextCoroutine()
    {
        foreach (var item in listSentences)
        {
            text.text=item;
            Debug.Log(text.text);
            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
            //yield return new WaitForSeconds(1.2f);
        }
 
    }
    public void closeimage()
    {
        renderer.gameObject.SetActive(false);
    }
    // public void closetext()
    // {
    //     text.text ="";
    //     count=0;
    //     listSentences.Clear();
    //     textPanel.SetActive(false);
    // }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (renderer.gameObject.activeSelf) //activeSelf gameobject on/off 판단
                renderer.gameObject.SetActive(false);
        }
            
        if(Input.GetKeyDown(KeyCode.Escape)) //esc
        {
            StopAllCoroutines();
            text.text ="";
            listSentences.Clear();
            textPanel.SetActive(false);
        }
    }


}
