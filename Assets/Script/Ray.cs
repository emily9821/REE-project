using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    public RaycastHit2D hit;
    LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, Vector3.forward*50, Color.red);
        hit= Physics2D.Raycast(this.transform.position, this.transform.forward, 30.0f,layerMask);
        //Physics.Raycast(this.transform.position, this.transform.forward,out hit, 30.0f)
        if(hit.collider != null)
        {
            Debug.Log(hit.transform.name);
        }
    }
}
