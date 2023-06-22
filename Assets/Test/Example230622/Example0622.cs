using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example0622 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.right);
        Debug.DrawLine(transform.position, transform.forward);
    }
}
