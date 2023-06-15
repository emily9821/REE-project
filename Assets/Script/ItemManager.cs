using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Text text;
    public GameObject scanObject;

    public void Action(GameObject scanobj)
    {
        scanObject = scanobj;
        text.text="이것의 이름은 "+ scanObject.name+"이다.";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
