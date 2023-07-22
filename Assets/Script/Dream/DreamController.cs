using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DreamController : MonoBehaviour
{
    public static DreamController instance; //생성

    public Dream[] dreams; //day

    public SpriteRenderer renderer;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text="";
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
            renderer.sprite=dream.img;
            renderer.gameObject.transform.localScale= new Vector3(150,150,1);
            renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
            foreach (var _text in dream.detailDescription)
            {
                text.text=_text;
                Debug.Log(text.text);
                yield return new WaitForSeconds(dream.waitTime);
            }
        }
    }
}

[System.Serializable]
public class Dream
{
    public string dreamName;
    public string[] detailDescription;
    public float waitTime;
    public Sprite img;
}