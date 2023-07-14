using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    
    //public Sprite target;
    //public SpriteRenderer view;

    public ObjData objData;
    public GameObject scanObj;

    //public RaycastHit2D hit;
    //LayerMask layerMask;
    public bool isclue;

    GameObject imgObject;
    private OrderManager theOrder;
     
  

    void Start()
    {
      //theclue=Resources.Load<GameObject>("ObjectImage");
      theOrder= FindObjectOfType<OrderManager>();
    }

    public void Action(GameObject scanObj)
    {
        if(isclue)
        {
            isclue=false;
        }
        else
        {
            isclue=true;
            objData=scanObj.GetComponent<ObjData>();
            showimage(objData.id);
        }
    }

    public void showimage(int id)
    {
        //target=theclue.getImage(id);
    
        if(id == null)
        {
            isclue = false;
            return;
        }
    
        else
        {
            Debug.Log(id);
            if( id== 200)
            {
                imgObject=Resources.Load<GameObject>("outview");
            }
            imgObject=Instantiate(imgObject); 
            Transform p = GameObject.Find("Player").transform;
            imgObject.transform.SetParent (p);
            imgObject.transform.localPosition=Vector3.zero;
            imgObject.name = "outview";
            
            //view.sprite=target;
            Debug.Log("outview");
            theOrder.Move();
        }
        
        //isclue=true;
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

    void Update()
    {

    }

   /* void Start()
    {
        thePM=FindObjectOfType<PlayerManager>();
        theOrder= FindObjectOfType<OrderManager>();
        scenename roomname;

        layerMask = LayerMask.GetMask("NoPassing");
        target = Resources.Load<GameObject>("Clue Event Controller");
        target = Instantiate(target);
        
    }
*/

    

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
