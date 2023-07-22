using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamManager : MonoBehaviour
{
    public static DreamManager instance; //생성
    #region Singleton
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            
        }
    }
    #endregion Singleton

    public Dream[] dream1; //day1
    public Dream[] dream2; //day2
    public Dream[] dream3; //day3
    public Dream[] dream4; //day4

    public static List<Dream[]> DREAM = new List<Dream[]>();

    public SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        DREAM.Add(dream1); //day1
        DREAM.Add(dream2); //day2
        DREAM.Add(dream3); //day3
        DREAM.Add(dream4); //day4

        ShowAllDreams();
    }

    private void ShowAllDreams()
    {
        StartCoroutine(ShowDream(PlayerManager.day));
    }

    IEnumerator ShowDream(int day)
    {
        foreach (var dream in DREAM[day-1])
        {
            renderer.sprite=dream.img;
            renderer.gameObject.transform.localScale= new Vector3(150,150,1);
            renderer.gameObject.transform.position=PlayerManager.instance.transform.position;
            foreach (var text in dream.detailDescription)
            {
                Debug.Log(text);
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