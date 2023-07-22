using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamSample : MonoBehaviour
{
    public _Dream[] dreams;

    // Start is called before the first frame update
    void Start()
    {
        ShowAllDreams();
    }

    private void ShowAllDreams()
    {
        StartCoroutine(ShowDream());
    }

    IEnumerator ShowDream()
    {
        foreach (var dream in dreams)
        {
            yield return new WaitForSeconds(dream.waitTime);
            Debug.Log(dream.detailDescription);
        }
    }
}

[System.Serializable]
public class _Dream
{
    public string dreamName;
    public string detailDescription;
    public float waitTime;
    public Sprite img;
}