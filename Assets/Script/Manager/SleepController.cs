using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
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
        yield return new WaitForSeconds(sleepTime);
        Progress.WakeUp();
    }

    public enum Type
    {
        Sleep,
        WakeUp,
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space) && type == Type.Sleep && stageDay == PlayerManager.day)
        {
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
