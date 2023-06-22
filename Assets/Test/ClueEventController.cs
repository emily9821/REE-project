using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<<<<<<< Updated upstream
// 실질적으로 필요한 기능 구현
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