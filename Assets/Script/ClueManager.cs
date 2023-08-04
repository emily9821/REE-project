using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//해금
//GameEventLinker.IsAvailable("day2"); //day2 이벤트 등록 - 해금하는 시점 => 항상 true
//1. 파라미터,매개변수 모두 none => voidGameEventLinker.IsAvailable("day2",showText); //day2 이벤트 함수() 실행 시점
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

    public bool isclue=false;
    Sprite imgObject;
    public SpriteRenderer renderer;

    public TextMeshProUGUI text;
    public GameObject textPanel;
    private List<string> listSentences;
    private int count=0;

    void Start()
    {
        //Instantiate(Resources.Load<GameObject>("Item_Prefab"));
        text=DialogueManager.instance.text;
        textPanel=DialogueManager.instance.dialoguePanel;
        text.text= "";
        listSentences= new List<string>();
        count=0;
    }


    public int showimage(int _day,GameObject scanObj)
    {
        //Debug.Log("Day" + _day);
        //Debug.Log("scanobj" + scanObj);
        //이미지 로드
        foreach(var it in Item_Prefab.ITEM[_day-1])
        //    Debug.Log(it.Value.itemname);
        
        //Debug.Log(_day-1);
       // Debug.Log(Item_Prefab.ITEM[_day-1][scanObj.name].itemname);
        renderer.sprite=Item_Prefab.ITEM[_day-1][scanObj.name].img;

        if (renderer.sprite == null && Item_Prefab.ITEM[_day-1][scanObj.name].description == null)
        {
            isclue = false;
            return 0;
        }
        else if (renderer.sprite != null)
        {
            renderer.gameObject.SetActive(true);
            renderer.gameObject.transform.localScale= new Vector3(150,150,1);
            renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
            //Debug.Log(Item_Prefab.ITEM[_day-1][scanObj.name].itemname);
        }
    
        showText(_day, scanObj);
        GameEventLinker.NewEvent(Item_Prefab.ITEM[_day-1][scanObj.name].itemname,true);
        //Debug.Log(Item_Prefab.ITEM[_day-1][scanObj.name].itemname + GameEventLinker.IsAvailable(Item_Prefab.ITEM[_day-1][scanObj.name].itemname));
        isclue = false;
        return 100;

    }

    public void showText(int _day,GameObject scanObj)
    {
        SFX.Play(SoundEffect.item);
        textPanel.SetActive(true);
        foreach (var item in Item_Prefab.ITEM[_day-1][scanObj.name].description)
        {
            listSentences.Add(item);
            //Debug.Log(listSentences);
        }

        StartCoroutine(starttextCoroutine());
        
    }
    
    IEnumerator starttextCoroutine()
    {
        foreach (var item in listSentences)
        {
            text.text=item;
            yield return null; //중첩 실행 방지
            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
            //yield return new WaitForSeconds(1.2f);
        }
        listSentences.Clear();
        text.text=null;
        textPanel.SetActive(false);
 
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (renderer.gameObject.activeSelf) //activeSelf gameobject on/off 판단
                renderer.gameObject.SetActive(false);
        }
            
    }

}
