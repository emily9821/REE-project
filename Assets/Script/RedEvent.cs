using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{

    public Dialogue dialogue;

    private DialogueManager theDM;
    private OrderManager theOrder;
    private PlayerManager thePlayer;

    private bool flag; //default = false


    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theOrder= FindObjectOfType<OrderManager>();
        thePlayer=FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!flag && Input.GetKey(KeyCode.Z) && thePlayer.animator.GetFloat("DirY") == 1f)
        {
            flag = true;
            StartCoroutine(ventCoroutine());
        }
    }

    IEnumerator ventCoroutine()
    {
        theOrder.NotMove();

        theDM.ShowDialogue(dialogue);
        
        yield return new WaitUntil(() => !theDM.talking);

        theOrder.Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
