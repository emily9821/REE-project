using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JJH;

public class AboutEventSystem : MonoBehaviour
{
    private JJHManager manager;
    void Awake()
    {
        Debug.Log("Awake");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void Start()
    {
        manager = JJHManager.Inst;
        Debug.Log("Start");

        manager.order.NotMove();
        manager.order.Move();
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
