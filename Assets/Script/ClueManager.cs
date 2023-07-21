using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    
    //public Sprite target;
    //public SpriteRenderer view;

    public ObjData objData;
    int id;
    public GameObject scanObj;
    private string imgname;

    //public RaycastHit2D hit;
    //LayerMask layerMask;

    public bool isclue=false;

    GameObject imgObject;
    public GameObject prefab_text;
    private DataBaseManager theDB; 
    private int i_db=0;

    void Start()
    {
      //theclue=Resources.Load<GameObject>("ObjectImage");
        //theOrder= FindObjectOfType<OrderManager>();
        theDB=FindObjectOfType<DataBaseManager>();
    }


    public int showimage(int currentdate,GameObject scanObj)
    {
        objData=scanObj.GetComponent<ObjData>();
        if(objData == null)
            return 0;
        else
        {
            id=objData.id;

            if(id == null)
            {
                isclue = false;
                return 0;
            }
            else
            {
                Debug.Log(id);
                //obj ID 에 따른 이미지 로드
                switch(id)
                {
                    case 210: //room1 책상 위 신문기사
                        //imgObject=Resources.Load<GameObject>("신문");
                        break;
                    case 220:  //작업실 문 앞 메모지
                        //imgObject=Resources.Load<GameObject>("메모지");
                        break;
                    case 230: //작업실 책상 위 사진
                        //imgObject=Resources.Load<GameObject>("형제 셀피");
                        break;
                    case 250:  //베란다 낙간 도심 풍경
                        imgObject=Resources.Load<GameObject>("ItemImg/"+"outview");
                        imgname="outview";
                        break;
                    default:
                        break;
                }
                
                imgObject=Instantiate(imgObject); 
                Transform p = GameObject.Find("Player").transform;
                imgObject.transform.SetParent (p);
                imgObject.transform.localPosition=Vector3.zero;
                imgObject.name = imgname;
                Debug.Log(imgname);
                isclue = false;

                // FindImgItem(id, currentdate);
                return 1;
            }
        }
        
        /*
        if(message != null)
        {
            talk.dialogue.sentences=(string[])message.Clone();
            theDM.ShowDialogue(talk.dialogue);
        }
        
        else
        {
            Debug.Log("noMessage");

            theOrder.Move();
        }
        */
    }


    public void showText()
    {
        var clone=Instantiate(prefab_text, PlayerManager.instance.transform.position, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<PopupText>().text.text = theDB.itemList1[i_db].imgDescription;
        clone.transform.SetParent(this.transform);
    }

    day - obj  

 
       public void FindImgItem(int _ObjID, int _day) //DB 검색
    {
        // switch(_day) //day마다 다른 DB list 검색
            if(_day==1) 
            {
                for( int i=0; i< theDB.itemList1.Count; i++)
                {
                    if(_ObjID == theDB.itemList1[i].imgId)
                    {
                        // imgObject=Resources.Load<GameObject>("ItemImg/"+theDB.itemList1[i].imgname);
                        i_db=i;
                        
                        break;
                    }
                }
            }
            // else if(_day ==2)
            // {
            //     for( int i=0; i< theDB.itemList2.Count; i++)
            //     {
            //         if(_ObjID == theDB.itemList2[i].imgid)
            //         {
            //             imgObject=Resources.Load<GameObject>(theDB.itemList2[i].imgname);
            //             break;
            //         }
            //     }
            // }
            // else if(_day==3) 
            // {
            //     for( int i=0; i< theDB.itemList3.Count; i++)
            //     {
            //         if(_ObjID == theDB.itemList3[i].imgid)
            //         {
            //             imgObject=Resources.Load<GameObject>(theDB.itemList3[i].imgname);
            //             break;
            //         }
            //     }
            // }
            // else if(_day ==4)
            // {
            //     for( int i=0; i< theDB.itemList4.Count; i++)
            //     {
            //         if(_ObjID == theDB.itemList4[i].imgid)
            //         {
            //             imgObject=Resources.Load<GameObject>(theDB.itemList4[i].imgname);
            //             break;
            //         }
            //     }
            // }
            // else if(_day ==5)
            // {
            //     for( int i=0; i< theDB.itemList5.Count; i++)
            //     {
            //         if(_ObjID == theDB.itemList5[i].imgid)
            //         {
            //             imgObject=Resources.Load<GameObject>(theDB.itemList5[i].imgname);
            //             break;
            //         }
            //     }
            // }
            else
            {
                Debug.LogError("데이터베이스에 해당 ID 값을 가진 object img/item 이 존재하지 않습니다.");
            }
        Debug.Log(_day);
        
    }
    
    public void closeimage()
    {
        Destroy(imgObject,2f);
    }

    void Update()
    {
    }

    

    // Update is called once per frame
    /*void Update()
    {
        roomnameValue=thePM.currentMapName;
        switch(roomnameValue)
        {
            case "room1":
                //images=target.room1Images;
                break;
            case "room2":
                //images=target.room2Images;
                break;
            case "veranda":
                //images=target.verandaImages;
                if(thePM.playobject=="wall_left" & Input.GetKeyDown(KeyCode.Space))
                {
                    showimage();
                }
                break;
            case "livingroom":
                //images=target.livingroomImages;
                break;
            case "workspace":
                //images=target.workspaceImages;
                break;
            case "lab":
                //images=target.labImages;
                break;
            default:
                break;

        }

        if(clue)
        {   
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(target);
                clue=false;
                theOrder.Move();
            }
        }
    }
    */

}
