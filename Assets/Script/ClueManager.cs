using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    
    public Sprite target;
    public SpriteRenderer view;
    public ObjData objData;
    public GameObject scanObj;

    public RaycastHit2D hit;
    LayerMask layerMask;
    bool isclue=true;

    //private PlayerManager thePlayer;
    private OrderManager theOrder;
    private DialogueManager theDM;
    private TalkDialogue talk;
    private ObjectImage theclue;

    void Start()
    {
      //theclue=Resources.Load<GameObject>("ObjectImage");
      theOrder= FindObjectOfType<OrderManager>();
      theDM= FindObjectOfType<DialogueManager>();
      talk= FindObjectOfType<TalkDialogue>();
      theclue=FindObjectOfType<ObjectImage>();
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
            showimage(objData.id, scanObj);
        }
    }

    public void showimage(int id,GameObject targetObject)
    {
        target=theclue.getImage(id);
    
        if(target == null)
        {
            isclue = false;
            return;
        }
        else
        {
            theOrder.NotMove();
            Transform p = GameObject.Find("Player").transform;
            targetObject.transform.SetParent (p,false);
            targetObject.name = "Clue Event Controller";
            view.sprite=target;
            Debug.Log("clue event controller");
        }
        
        isclue=true;
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
