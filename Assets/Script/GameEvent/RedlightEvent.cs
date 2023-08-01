using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedlightEvent : MonoBehaviour
{
    private bool isRed=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("redlightoptions");
            StartCoroutine(redlight());
        }
    }
    void Update ()
    {
      /*   if(Input.GetKeyDown(KeyCode.Space) && !isRed)
        {
            isRed=true;
            StartCoroutine(redlight());
        } */
    }

    IEnumerator redlight()
    {
        var options= EventOptionHandler.Call("redlight");
        options.AddEvent(() => Destroy(options.gameObject));
        yield return new WaitUntil(() => options == null);
        // Instantiate(Resources.Load<GameObject>("Fade Manager"));
        // isRed=false;
        // //FadeManager.FlashIn();
    }
}