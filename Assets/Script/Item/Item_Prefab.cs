using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Prefab : MonoBehaviour
{
    public static SceneItemManager management;
    public Sprite _sprite;
    public static List<Dictionary<string, ImgEventItem>> ITEM = new List<Dictionary<string, ImgEventItem>>();
    
    void Start()
    {
        management = FindObjectOfType<SceneItemManager>();

        ITEM.Clear(); //정적 변수 초기화

        ITEM.Add(new Dictionary<string, ImgEventItem>()); //day1
        ITEM.Add(new Dictionary<string, ImgEventItem>()); //day2
        ITEM.Add(new Dictionary<string, ImgEventItem>()); //day3
        ITEM.Add(new Dictionary<string, ImgEventItem>()); //day4
        ITEM.Add(new Dictionary<string, ImgEventItem>()); //day5
    
        foreach (var item in management.items)
        {
            ITEM[item.day-1].Add(item.name,item);
        }

    }
}