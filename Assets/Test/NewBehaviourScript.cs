using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefab2=Resources.Load<GameObject>("room-2-carpet_0");
        Instantiate(prefab2);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
