using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
        GameObject target = Resources.Load<GameObject>("Clue Event Controller");

        Transform p = GameObject.Find("Managers").transform;

        target = Instantiate(target);
        target.name = "Clue Event Controller";
        target.transform.parent = p;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Generate()
    {
        Instantiate(player, Vector3.zero, Quaternion.identity);

    }
}
