using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupText : MonoBehaviour
{
    public float destroyTime;

    public TextMeshProUGUI text;
    public GameObject textPanel;

    private Vector3 vector;

    void start()
    {
        textPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //vector &textvector
        text.transform.localPosition=Vector3.zero;

        destroyTime -= Time.deltaTime;

        if(destroyTime<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
