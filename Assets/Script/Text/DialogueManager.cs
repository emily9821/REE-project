using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance; //생성

    #region Singleton
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(transform.root.gameObject);
            instance = this;
        }
        else
        {
            Destroy(transform.root.gameObject);
            
        }
    }
    #endregion Singleton
    
    public TextMeshProUGUI text;
    public GameObject dialoguePanel;

    private List<string> listSentences;

    private int count; // 대화 진행 상황 카운트

    public bool talking = false;

    private OrderManager theOrder;
    //private PlayerManager thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        count=0;
        text.text= "";
        listSentences = new List<string>();
        if (dialoguePanel.activeSelf) //activeSelf gameobject on/off 판단
                talking= false;
        dialoguePanel.SetActive(talking);
        theOrder= FindObjectOfType<OrderManager>();
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        //string[] dialogue=(string[])sentences.Clone();
        talking=true;
        theOrder.NotMove();
        for(int i = 0; i< dialogue.sentences.Length; i++)
        {
            listSentences.Add(dialogue.sentences[i]);
            Debug.Log(listSentences[i]);
        }
        dialoguePanel.SetActive(talking);
        StartCoroutine(StartDialogueCoroutine());
    }

    public void ExitDialogue()
    {
        talking=false;
        text.text="";
        count =0;
        listSentences.Clear();
        dialoguePanel.SetActive(talking);
        theOrder.Move();
    }

    IEnumerator StartDialogueCoroutine()
    {
        //Debug.Log(count);
        yield return new WaitForSeconds(0.01f);
        for(int i=0; i<listSentences[count].Length ; i++)
        {
            text.text += listSentences[count][i]; //1글자씩 출력
            yield return new WaitForSeconds(0.01f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(talking)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                count++;
                text.text= "";
                if(count== listSentences.Count)
                {
                    StopAllCoroutines();
                    ExitDialogue();
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            }
        }
        
    }
}
