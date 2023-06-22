using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueEventController : MonoBehaviour
{
    public SpriteRenderer view;
    public List<Sprite> images = new List<Sprite>();

    void Start()
    {
        StartCoroutine(ImageChanger());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ImageChanger());
            //view.enabled=false;
        }
    }

    IEnumerator ImageChanger()
    {
        for (int i = 0; i < images.Count; i++)
        {
           view.sprite = images[i];
           yield return new WaitForSeconds(1);
        }
    }
}
