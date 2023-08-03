using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doorlock_lab : MonoBehaviour
{
    public Transform pswTextStorage;
    public TMP_Text[] pwdText;

    private int[] answer_workspace = new int[4] { 0, 6, 0, 6 };
    private int[] answer_lab = new int[4] { 1, 9, 7, 2 };
    private int[] password = new int[4];
    private readonly WaitForSeconds waitForClear = new WaitForSeconds(1f);
    private bool isPwdEnabled = true;

    void Start()
    {
        Clear();
    }

    public void PressPasswordButton(int i)
    {
        if (!isPwdEnabled)
            return;

        SFX.Play(SoundEffect.doorlick_button);
        for (int j = 0; j < password.Length; j++)
        {
            if (password[j] == -1)
            {
                password[j] = i;
                pwdText[j].text = i.ToString();
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
        isPwdEnabled = true;
        for (int j = 0;j < password.Length; j++)
        {
            password[j] = -1;
            pwdText[j].text = "";
        }
    }

    private void CheckPassword(int[] answer)
    {
        for (int i = 0; i < password.Length; i++)
        {
            if (password[i] != answer[i])
            {
                StartCoroutine(OnPasswordWrong());
                return;
            }
        }
        StartCoroutine(OnPasswordRight(answer));
    }

    IEnumerator OnPasswordRight(int[] answer)
    {
        isPwdEnabled = false;
        SFX.Play(SoundEffect.doorlock_open);
        yield return waitForClear;

        Clear();
        Destroy(gameObject);

        if(answer==answer_lab)
            GameEventLinker.NewEvent("doorlock_lab",true); //등록 & 2번째(true) - 해금 // 해금확인 : isavailable
        if(answer==answer_workspace)
            GameEventLinker.NewEvent("doorlock_workspace",true);
    }

    IEnumerator OnPasswordWrong()
    {
        isPwdEnabled = false;
        SFX.Play(SoundEffect.doorlock_wrong);
        var originPos = pswTextStorage.position;
        float shakeTime = 0.5f;
        int power = 5;
        int isLeft = -1;
        while(shakeTime >= 0f)
        {
            power *= isLeft;
            pswTextStorage.position = originPos + power * Vector3.right;
            yield return new WaitForSeconds(0.04f);
            shakeTime -= 0.04f;
        }
        pswTextStorage.position = originPos;
        yield return waitForClear;
        Clear();
        Debug.Log("wrong");
        Destroy(gameObject);
    }
}
