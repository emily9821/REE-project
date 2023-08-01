using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.Events; //UnityEvent 사용
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EventOptionHandler : MonoBehaviour
{
    public Option[] options; //선택지들
    public UnityEvent onPlay;
    [Range(50f, 800f)]
    public float buttonYSize;

    private TMP_Text words;
    private Canvas palette; //캔버스
    private Button selection; //선택지 버튼
    private List<Button> buttons; //버튼
    private Vector2 btnOriginPos;
    private readonly WaitForSeconds waitTimeWhenWrong = new WaitForSeconds(2.5f);

    private void Awake()
    {
        palette = GetComponentInChildren<Canvas>();
        selection = palette.GetComponentInChildren<Button>(true); //palette 자식으로 selection 생성 캔버스안에 버튼 생성
        btnOriginPos = selection.transform.position;
    }

    public static EventOptionHandler Call(string monologueName) //생성자 재정의..?
    {
        var monologues = FindObjectsByType<EventOptionHandler>(FindObjectsSortMode.None); //개체를 정렬하지 않고 type 객체 전체 검색
        foreach (var item in monologues)
        {
            if (item.name == monologueName) //미션이름이 일치한다면 선택지 보여줌
            {
                item.Show();
                return item;
            }
        }
        var monologueInAsset = Resources.Load<EventOptionHandler>("MonologueEvents/" + monologueName); //해당 미션 로드
        if (monologueInAsset == null)
            return null;

        monologueInAsset = Instantiate(monologueInAsset);//미션 보여줌
        monologueInAsset.Show();
        return monologueInAsset;
    }

    public void AddEvent(Action onRight) //함수 추가
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (options[i].isRightAnswer)
                buttons[i].onClick.AddListener(onRight.Invoke);
        }
    }

    public void Show() //선택지 보여줌
    {
        buttons = new List<Button>();
        float initYPos = buttonYSize * (options.Length - 1) / 2f + btnOriginPos.y;
        selection.transform.position = new Vector2(btnOriginPos.x, initYPos);
        buttons.Add(selection); //버튼 생성

        SetSelectionDetail(selection, options[0]); //0번째 선택지 버튼 설정
        for (int i = 1; i < options.Length; i++)
        {
            Debug.Log(buttonYSize); ;
            var btnClone = Instantiate(selection, new Vector2(btnOriginPos.x, initYPos - buttonYSize * i), Quaternion.identity, palette.transform); 
            SetSelectionDetail(btnClone, options[i]); //다음 선택지 버튼 설정
            buttons.Add(btnClone); //다음 선택지 버튼 생성
        }

        buttons.ForEach(button => button.gameObject.SetActive(true)); //모든 버튼 true
    }

    private void SetSelectionDetail(Button btn, Option option)
    {
        btn.GetComponentInChildren<TMP_Text>().text = option.response; //선택지 내용 설정
        if(option.isRightAnswer) //정답 선택지인 경우 해당 함수 실행 (함수 설정)
        {
            btn.onClick.AddListener(onPlay.Invoke);
        }
        //btn.onClick.AddListener(() => Destroy(gameObject));
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
    public string response; //옵션 내용 
    public bool isRightAnswer = false; //option 응답 y/n
}