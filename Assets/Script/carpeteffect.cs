using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carpeteffect : MonoBehaviour 
{
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
                    GameEventLinker.NewEvent("doorlock_lab",false);
                    Instantiate(Resources.Load<GameObject>("Door Lock"));
                }
                if(GameEventLinker.IsAvailable("doorlock_lab"))
                {
                    GameEventLinker.NewEvent("doorlock_lab",true);
                    gameObject.SetActive(false);

                }
                    

            }
            
        }
    }
}