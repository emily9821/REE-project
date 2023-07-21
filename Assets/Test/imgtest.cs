using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imgtest : MonoBehaviour
{
    
    //public Sprite target;
    //public SpriteRenderer view;

    public GameObject prefab_text;
    public GameObject obj1 ;
    void Start()
    {
        obj1 = GameObject.Find("Square");
        showText();

    }

    public void showText()
    {
        var clone=Instantiate(prefab_text);
        clone.transform.position= obj1.transform.position;
        clone.GetComponent<PopupText>().text.text = "hello world";
        clone.transform.SetParent(this.transform);
    }
    
    void Update()
    {

    }
}