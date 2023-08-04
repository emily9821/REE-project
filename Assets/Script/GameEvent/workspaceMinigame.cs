using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class workspaceMinigame : MonoBehaviour 
{
    void Start()
    {
        //workspace 미니게임 실행
        if( PlayerManager.day ==3  )
        {
            if(!GameEventLinker.IsAvailable("workspace_minigame"))
            {
                Debug.Log("start minigame");
                Instantiate(Resources.Load<GameObject>("LabMinigame"));
   
            }
        }
    }
    
}


