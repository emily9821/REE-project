using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example0622 : MonoBehaviour
{
    public string collidedObjectName;
    public HOUSE_OBJECT detected;
    //collidedObject = 1
    // 1 -> TV
    // 2 -> COMPUTER
    // 3 -> RADIO
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.right);
        Debug.DrawLine(transform.position, transform.forward);


        //GetKeyDown -> Every frame
        if (Input.GetKeyDown(KeyCode.Space) && detected == HOUSE_OBJECT.TV)
        {
            // DO SOMETHING.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        detected = HOUSE_OBJECT.TV;
    }

    public enum HOUSE_OBJECT
    {
        TV,
        COMPUTER,
        RADIO,
    }
}
