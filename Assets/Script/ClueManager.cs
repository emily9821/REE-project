using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public GameObject scene;
    public GameObject target;
    
    public RaycastHit2D hit;
    LayerMask layerMask;

    bool clue=false;
    //private PlayerManager thePM;
    private OrderManager theOrder;

    void Start()
    {
        //thePM=FindObjectOfType<PlayerManager>();
        theOrder= FindObjectOfType<OrderManager>();

        layerMask = LayerMask.GetMask("NoPassing");
        hit= Physics2D.Raycast(this.transform.position, this.transform.forward, 30.0f,layerMask);
        target = Resources.Load<GameObject>("Clue Event Controller");
        if(hit.collider != null)
        {
            if(hit.transform.name == "Player" )
            {
                showimage();
            }
            else
            {
            Debug.Log(hit.transform.gameObject);
            }
        }
        Generate();

    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            showimage();
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
    }*/

    public void showimage()
    {
        theOrder.NotMove();
        clue=true;
        target = Resources.Load<GameObject>("Clue Event Controller");
        Transform p = GameObject.Find("Player").transform;
        target = Instantiate(target);
        target.transform.SetParent (p,false);
        target.name = "Clue Event Controller";
        
        //Instantiate(scene, Vector3.zero, Quaternion.identity);
        Debug.Log("clue event controller");
    }

    // Update is called once per frame
    void Update()
    {
        if(clue)
        {
           /* if(Input.GetKeyDown(KeyCode.Z))
            {
            
            Transform p = GameObject.Find("Player").transform;
            target = Instantiate(target);
            target.transform.SetParent (p,false);
            target.name = "Clue Event Controller";
            }*/
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(target);
                clue=false;
                theOrder.Move();
            }
        }
    }

    private void Generate()
    {
        Instantiate(scene, Vector3.zero, Quaternion.identity);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Instantiate(scene, Vector3.zero, Quaternion.identity);
            Debug.Log("clue event controller");
        }
        
    }*/
}
