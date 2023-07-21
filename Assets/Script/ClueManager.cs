using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//해금
//GameEventLinker.IsAvailable("day2"); //day2 이벤트 등록 - 해금하는 시점 => true
//1. 파라미터,매개변수 모두 voidGameEventLinker.IsAvailable("day2",showText); //day2 이벤트 함수() 실행
//2. if(GameEventLinker.IsAvailable("day2"))
public class ClueManager : MonoBehaviour
{
    public GameObject obj;
    private string imgname;

    private SceneItemManager sceneitemmanager;

    public bool isclue=false;
    Sprite imgObject;
    public SpriteRenderer renderer;

    void Start()
    {
        Instantiate(Resources.Load<GameObject>("Item_Prefab"));
        sceneitemmanager=FindObjectOfType<SceneItemManager>();
        renderer = GetComponent<SpriteRenderer>();
    }


    public int showimage(int _day,GameObject scanObj)
    {

        Debug.Log(_day);
        Debug.Log(scanObj);
        //item 찾기
        renderer.sprite=Item_Prefab.ITEM[_day][scanObj.name].img;

            if(renderer.sprite == null)
            {
                isclue = false;
                return 0;
            }
            else
            {
                //이미지 로드
                renderer.gameObject.SetActive(true);
                Debug.Log(scanObj.name);
                isclue = false;
                return 1;
            }
        
        
    }


    // public void showText()
    // {
    //     var clone=Instantiate(prefab_text, PlayerManager.instance.transform.position, Quaternion.Euler(Vector3.zero));
    //     clone.GetComponent<PopupText>().text.text = theDB.itemList1[i_db].imgDescription;
    //     clone.transform.SetParent(this.transform);
    // }

    
    public void closeimage()
    {
        renderer.gameObject.SetActive(false);
    }

    void Update()
    {

    }


}
