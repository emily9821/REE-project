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
    private readonly WaitForSeconds waitTimeWhenWrong = new WaitForSeconds(2.5f);

    private float ySize = 135f;

    private void Awake()
    {
        palette = GetComponentInChildren<Canvas>();
        selection = palette.GetComponentInChildren<Button>();
    }

    void Start()
    {
        Show();
    }

    public void Show()
    {
        float initYPos = ySize * options.Length / 2f;
        SpriteRenderer a;
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
    public bool isRightAnswer = false;
    public string answer;
    public string onFailed;
}