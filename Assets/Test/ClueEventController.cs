using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<<<<<<< Updated upstream
// ���������� �ʿ��� ��� ����
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