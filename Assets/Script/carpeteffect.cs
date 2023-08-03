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
            if(PlayerManager.day ==3)
            {
                ClueManager.instance.showText(3,gameObject);
                
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
    }
}