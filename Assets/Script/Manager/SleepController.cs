using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] //BoxCollider2D 자동 추가
public class SleepController : MonoBehaviour
{
    public int stageDay;
    public float sleepTime = 2f;
    public Type type;

    private static bool isSleeping = false;

    void Start()
    {
        if (type == Type.WakeUp && stageDay == PlayerManager.day)
        {
            isSleeping = false;

            Transform player = GameObject.FindAnyObjectByType<PlayerManager>().transform;
            player.position = transform.position;
        }
    }

    IEnumerator Sleeping()
    {
        isSleeping = true;
        PlayerManager.instance.notMove=true;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
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
