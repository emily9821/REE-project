using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carpeteffect : MonoBehaviour 
{
    public GameObject transferlab;
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.name == "Player"  && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("z");
            if(PlayerManager.day ==1)
            {
                ClueManager.instance.showText(1,gameObject);
                
                if(!GameEventLinker.IsAvailable("doorlock_lab"))
                {
                    StartCoroutine(doorlockCoroutine());
                }
            }
            
        }
        
    }
    IEnumerator doorlockCoroutine()
    {
        Instantiate(Resources.Load<GameObject>("Door Lock"));
        yield return new WaitUntil(()=>GameEventLinker.IsAvailable("doorlock_lab"));
        gameObject.SetActive(false);
        transferlab.SetActive(true);
        // var list = GameObject.FindObjectsByType<TransferMap>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        // for (int i = 0; i < list.Length; i++)
        // {
        //     if (list[i].gameObject.name == "Transfer_lab")
        //     {
        //         list[i].gameObject.SetActive(true);
        //         break;
        //     }
        // }

    }
}