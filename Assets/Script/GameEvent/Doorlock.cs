using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorlock : MonoBehaviour
{
    private int[] answer = new int[4] { 0, 6, 0, 6 };
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
        CheckPassword();
    }

    public void Clear()
    {
        for(int j = 0;j < password.Length; j++)
        {
            password[j] = -1;
        }
    }

    private void CheckPassword()
    {
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i] != answer[i])
            {
                OnPasswordWrong();
                return;
            }
        }
        OnPasswordRight();
    }

    private void OnPasswordRight()
    {
        Clear();
        Debug.Log("right");
    }

    private void OnPasswordWrong()
    {
        Clear();
        Debug.Log("wrong");
    }
}
