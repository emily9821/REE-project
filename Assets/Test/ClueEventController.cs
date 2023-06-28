using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueEventController : MonoBehaviour
{
    public SpriteRenderer view;
    public List<Sprite> room1Images = new List<Sprite>();
    public List<Sprite> room2Images = new List<Sprite>();
    public List<Sprite> verandaImages = new List<Sprite>();
    public List<Sprite> livingroomImages = new List<Sprite>();
    public List<Sprite> workspaceImages = new List<Sprite>();
    public List<Sprite> labImages = new List<Sprite>();

    void Start()
    {
        //StartCoroutine(ImageChanger());
    }

    void Update()
    {

    }

    /*IEnumerator ImageChanger()
    {
        for (int i = 0; i < images.Count; i++)
        {
           //view.sprite = images[i];
           yield return new WaitForSeconds(1);
        }
    }*/
}
