using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorlock_lab : MonoBehaviour
{
    //private int[] answer = new int[4] { 0, 6, 0, 6 };
    private int[] answer_workspace = new int[4] { 0, 6, 0, 6 };
    private int[] answer_lab = new int[4] { 1, 9, 7, 2 };
    private int[] password = new int[4];

    void Start()
    {
        Clear();
    }

    public void PressPasswordButton(int i)
    {
        for (int j = 0; j < password.Length; j++)
        {
            if (password[j] == -1)
            {
                password[j] = i;
                if (j != 3)
                    return;
            }
        }
        if(PlayerManager.instance.currentMapName == "hallway")
        {
            CheckPassword(answer_workspace);
        }
        if(PlayerManager.instance.currentMapName == "room2")
        {
            CheckPassword(answer_lab);
        }
        //CheckPassword();
    }

    public void Clear()
    {
        for(int j = 0;j < password.Length; j++)
        {
            password[j] = -1;
        }
    }

    private void CheckPassword(int[] answer)
    {
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i] != answer[i])
            {
                OnPasswordWrong();
                return;
            }
        }
        OnPasswordRight(answer);
    }

    private void OnPasswordRight(int[] answer)
    {
        Clear();
        Destroy(gameObject);
        Debug.Log("right");
        if(answer==answer_lab)
            GameEventLinker.NewEvent("doorlock_lab",true); //등록 & 2번째(true) - 해금 // 해금확인 : isavailable
        if(answer==answer_workspace)
            GameEventLinker.NewEvent("doorlock_workspace",true);
    }

    private void OnPasswordWrong()
    {
        Clear();
        Debug.Log("wrong");
    }
}
