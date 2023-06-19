using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.UI;

public class AboutTransform : MonoBehaviour
{
    // Unity -> Transform : Position, Rotation, Scale...
    // Transform -> Must have item.
    // GetComponent
    public Transform parent;

    // caching
    //public CanvasScaler scaler;

    private CanvasScaler scaler;

    void Start()
    {
        //transform.SetParent(parent);
        //transform.SetSiblingIndex(0);
        //transform.parent = parent;
        //transform.root.gameObject.SetActive(false);
        //transform.parent = null;

        //scaler = transform.parent.GetComponent<CanvasScaler>();
        //scaler = transform.GetComponentInParent<CanvasScaler>();
        //scaler = transform.GetComponentInChildren<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 관통되는 충돌 (Physics X)
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    // 관통되지 않는 충돌 (Physics O)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision has no tag or name
        //collision's gameObject have it
        collision.transform.GetComponent<AudioSource>().Play();


    }
}
