using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectImage : MonoBehaviour
{
    Dictionary<int, Sprite> imageData;
    public Sprite[] images;

    void Awake()
    {
        imageData=new Dictionary<int, Sprite>();
        GenerateData();

    }
    void GenerateData()
    {
        imageData.Add(100,images[0]);

    }

    public Sprite getImage(int id)
    {
        return imageData[id];
    }
}
