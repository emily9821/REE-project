using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))] //BoxCollider2D 자동 추가
public class SleepController : MonoBehaviour
{
    public int stageDay;
    public float sleepTime = 2f;
    public Type type;

    public static bool isSleeping = false;
    private Color _color;

    private TextMeshProUGUI text;
    private GameObject textPanel;

    void Start()
    {
        text=DialogueManager.instance.text;
        textPanel=DialogueManager.instance.dialoguePanel;
        text.text= "";
        _color=new Color(0,0,0);

        if (type == Type.WakeUp && stageDay == PlayerManager.day)
        {
            isSleeping = false;
            Transform player = GameObject.FindAnyObjectByType<PlayerManager>().transform;
            player.position = transform.position;
            
            //start 0일차
            if (PlayerManager.day == 0)
            {
                Debug.Log(PlayerManager.day);
                PlayerManager.instance.notMove=true;
                StartCoroutine(starting());
            }

            //ending 5일차
            if (PlayerManager.day == 5)
            {
                PlayerManager.instance.notMove=true;
                StartCoroutine(startending());
            }
        }
    }

    IEnumerator starting()
    {
        SFX.Play(SoundEffect.phone_call_ringing);
        yield return new WaitForSeconds(3f);;
        SFX.Play(SoundEffect.phone_call_take_on);
        Instantiate(Resources.Load<GameObject>("Dream/" + 0));
        yield return new WaitUntil(()=>GameEventLinker.IsAvailable("Dream"+0));
        SFX.Play(SoundEffect.phone_call_take_off);
        PlayerManager.day ++;
        Debug.Log(PlayerManager.day);
        PlayerManager.instance.notMove=false;
        SceneManager.LoadScene("room1");
    }
    

    IEnumerator startending()
    {
        if (PlayerManager.instance.ending == "happy")       
            Instantiate(Resources.Load<GameObject>("Dream/" + "happy"));
        else if (PlayerManager.instance.ending == "sad")        
            Instantiate(Resources.Load<GameObject>("Dream/" + "sad"));
        
        yield return new WaitUntil(()=>GameEventLinker.IsAvailable("Dream"+5));
        
        if (PlayerManager.instance.ending == "happy") 
            _color= new Color(1,1,1);     //white 
        else if (PlayerManager.instance.ending == "sad")
            _color= new Color(0,0,0);      //black
            
        FadeManager.StartFadeOut(_color);
        
        //메인 메뉴로 이동
        SceneManager.LoadScene("title"); 
    }

    IEnumerator Sleeping()
    {
        isSleeping = true;
        PlayerManager.instance.notMove=true;
        _color=new Color(0,0,0);
        FadeManager.StartFadeOut(_color);
        yield return null;
        startdream();
        yield return new WaitUntil(()=>GameEventLinker.IsAvailable("Dream"+stageDay));
        //yield return new WaitForSeconds(sleepTime);
        PlayerManager.instance.notMove=false;
        Progress.WakeUp();
    }

    public void startdream()
    {
        if(!GameEventLinker.IsAvailable("Dream"+stageDay))
        {
            Debug.Log("dream");
            Instantiate(Resources.Load<GameObject>("Dream/"+stageDay));
        }
    }

    public enum Type
    {
        Sleep,
        WakeUp,
    }

    IEnumerator day3ending()
    {
        textPanel.SetActive(true);
        text.text=" 어딘가 익숙한 풍경인데… ";
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        _color=new Color(0,0,0);  
        FadeManager.StartFadeOut(_color);
        yield return null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(PlayerManager.day ==3 && stageDay==3)
        {
            
            if (Progress.Sleep())
            {
                StartCoroutine(day3ending());
                Debug.Log("sleep");
                StartCoroutine(Sleeping());
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && type == Type.Sleep && stageDay == PlayerManager.day) //collision.gameObject.name == "Player" && 
        {
            Debug.Log(type);
            Debug.Log(stageDay);
            if (isSleeping)
                return;

            if (Progress.Sleep())
            {
                Debug.Log("sleep");
                StartCoroutine(Sleeping());
            }
        }
    }
}
