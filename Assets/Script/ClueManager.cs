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

    //public RaycastHit2D hit;
    //LayerMask layerMask;

    public bool isclue=false;

    GameObject imgObject;
     
  

    void Start()
    {
      //theclue=Resources.Load<GameObject>("ObjectImage");
    //   theOrder= FindObjectOfType<OrderManager>();
    }

    // public void Action(GameObject scanObj)
    // {
    //     if(isclue)
    //     {
    //         isclue=false;
    //     }
    //     else
    //     {
    //         // isclue=true;
    //         objData=scanObj.GetComponent<ObjData>();
    //         showimage(objData.id); 
    //     }
    // }


    public int showimage(GameObject scanObj)
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
                switch(id)
                {
                    case 210: //room1 팩상 위 신문기사
                        //imgObject=Resources.Load<GameObject>("신문");
                        break;
                    case 220:  //작업실 문 앞 메모지
                        //imgObject=Resources.Load<GameObject>("메모지");
                        break;
                    case 230: //작업실 책상 위 사진
                        //imgObject=Resources.Load<GameObject>("형제 셀피");
                        break;
                    case 250:  //베란다 낙간 도심 풍경
                        imgObject=Resources.Load<GameObject>("outview");
                        break;
                    default:
                        break;
                }
                
                imgObject=Instantiate(imgObject); 
                Transform p = GameObject.Find("Player").transform;
                imgObject.transform.SetParent (p);
                imgObject.transform.localPosition=Vector3.zero;
                imgObject.name = "outview";
                Debug.Log("outview");
                isclue = false;
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
