using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedlightEvent : MonoBehaviour
{
    private bool isRed=false;
    public SpriteRenderer renderer;
    public Sprite img;
    public Color color;
    private EventOptionHandler redLightEvent;
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
    }

    IEnumerator redlight()
    {
        if (redLightEvent == null)
            redLightEvent = EventOptionHandler.Call("redlight");
        redLightEvent.gameObject.SetActive(true);
        redLightEvent.AddEvent(() => redLightEvent.gameObject.SetActive(false));
        yield return null;
        
    }

    public void onred()
    {
        SFX.Play(SoundEffect.light_switch);
        Debug.Log("red");
        if(!isRed)
        {
            renderer.sprite=img;
            renderer.color=new Color(1,1,1,0.4f);
            renderer.gameObject.SetActive(true);
            renderer.gameObject.transform.localScale= new Vector3(150,150,1);
            renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
            isRed=true;
        }
        else if(isRed)
        {
            renderer.gameObject.SetActive(false);
            isRed=false;
        }
    }

    public void offred()
    {
        if(isRed)
        {
            renderer.gameObject.SetActive(false);
            isRed=false;
        }
    }
}