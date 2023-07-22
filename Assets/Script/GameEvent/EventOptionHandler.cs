using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EventOptionHandler : MonoBehaviour
{
    public Option[] options;
    public UnityEvent onPlay;
    [Range(50f, 800f)]
    public float buttonYSize;

    private TMP_Text words;
    private Canvas palette;
    private Button selection;
    private List<Button> buttons;
    private readonly WaitForSeconds waitTimeWhenWrong = new WaitForSeconds(2.5f);

    private Vector2 btnOriginPos;

    private void Awake()
    {
        palette = GetComponentInChildren<Canvas>();
        selection = palette.GetComponentInChildren<Button>(true);
        btnOriginPos = selection.transform.position;
    }

    public static EventOptionHandler Call(string monologueName)
    {
        var monologues = FindObjectsByType<EventOptionHandler>(FindObjectsSortMode.None);
        foreach (var item in monologues)
        {
            if (item.name == monologueName)
            {
                item.Show();
                return null;
            }
        }
        var monologueInAsset = Resources.Load<EventOptionHandler>("MonologueEvents/" + monologueName);
        if (monologueInAsset == null)
            return null;

        monologueInAsset = Instantiate(monologueInAsset);
        monologueInAsset.Show();
        return monologueInAsset;
    }

    public void AddEvent(Action onRight)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (options[i].isRightAnswer)
                buttons[i].onClick.AddListener(onRight.Invoke);
        }
    }

    public void Show()
    {
        buttons = new List<Button>();
        float initYPos = buttonYSize * (options.Length - 1) / 2f + btnOriginPos.y;
        selection.transform.position = new Vector2(btnOriginPos.x, initYPos);
        buttons.Add(selection);

        SetSelectionDetail(selection, options[0]);
        for (int i = 1; i < options.Length; i++)
        {
            var btnClone = Instantiate(selection, new Vector2(btnOriginPos.x, initYPos - buttonYSize * i), Quaternion.identity, palette.transform);
            SetSelectionDetail(btnClone, options[i]);
            buttons.Add(btnClone);
        }

        buttons.ForEach(button => button.gameObject.SetActive(true));
    }

    private void SetSelectionDetail(Button btn, Option option)
    {
        btn.GetComponentInChildren<TMP_Text>().text = option.response;
        if(option.isRightAnswer)
        {
            btn.onClick.AddListener(onPlay.Invoke);
        }
        btn.onClick.AddListener(() => Destroy(gameObject));
    }

    private void ShowText(string msg)
    {
        StartCoroutine(AnswerRoutine(msg));
    }

    private void OnOffAllButton(bool isOn = false)
    {
        buttons.ForEach(x => x.gameObject.SetActive(isOn));
    }

    private void SetMainText(string msg) => words.text = msg;

    IEnumerator AnswerRoutine(string msgWhenWrong)
    {
        OnOffAllButton(false);
        SetMainText(msgWhenWrong);
        yield return waitTimeWhenWrong;
        SetMainText("");
        OnOffAllButton(true);
    }
}

[System.Serializable]
public class Option
{
    public string response;
    public bool isRightAnswer = false;
}