using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EventOptionHandler : MonoBehaviour
{
    public Option[] options;
    public UnityEvent onPlay;
    [Space]
    public TMP_Text words;

    private Canvas palette;
    private Button selection;
    private List<Button> buttons;

    private void Awake()
    {
        palette = GetComponentInChildren<Canvas>();
        selection = palette.GetComponentInChildren<Button>();
    }

    void Start()
    {
        
    }

    public void Show()
    {
        SetSelectionDetail(selection, options[0]);
        for (int i = 1; i < options.Length; i++)
        {
            var btnClone = Instantiate(selection, palette.transform);
            SetSelectionDetail(btnClone, options[i]);
        }
    }

    private void SetSelectionDetail(Button btn, Option option)
    {
        btn.GetComponentInChildren<TMP_Text>().text = option.answer;
        if(option.isRightAnswer)
        {
            btn.onClick.AddListener(onPlay.Invoke);
        }
        else
        {
            btn.onClick.AddListener(() => ShowText(option.onFailed));
        }
    }

    private void ShowText(string msg)
    {

    }
}

[System.Serializable]
public class Option
{
    public bool isRightAnswer = false;
    public string answer;
    public string onFailed;
}