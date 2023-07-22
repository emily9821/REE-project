using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example0721Main : MonoBehaviour
{
    public List<FruitItem> fruitItems;

    public Sprite _sprite;

    public SceneItemManagement management;
    public List<Dictionary<int, Item>> ITEM = new List<Dictionary<int, Item>>();

    void Start()
    {
        //EventOptionHandler.Call("Apple");
        var e = EventOptionHandler.Call("Room1");
        e.AddEvent(() => Debug.Log("Good"));
        //management = FindObjectOfType<SceneItemManagement>();

        //ITEM.Add(new Dictionary<int, Item>()); // day 0
        //ITEM.Add(new Dictionary<int, Item>()); // day 1
        //ITEM.Add(new Dictionary<int, Item>());
        //ITEM.Add(new Dictionary<int, Item>());
        //ITEM.Add(new Dictionary<int, Item>());

        //_sprite = ITEM[2][300].img;

        //fruitItems.Add(new FruitItem());
        //FruitItem fruit = fruitItems.Find(target => target.id == 0);
        //int fruitIdx = fruitItems.FindIndex(x => x.name == "Strawberry");
        //Debug.Log(fruitIdx);
    }

    public void Add(int id, int day)
    {
        Item target = management.items.Find(x => x.id == id);

        ITEM[day].Add(id, target);
    }

    void Update()
    {

    }

    private void OnValidate()
    {
        for (int i = 0; i < fruitItems.Count; i++)
        {
            fruitItems[i].id = i;
        }
    }
}

[System.Serializable] //직렬화 -> 코드를 읽을 수 있는 데이터로 변경.
public class FruitItem
{
    public int id { get; set; }
    public string name;
    public string[] description;
    public Sprite icon;
    public Day day;
}

public enum Day
{
    Day1,
    Day2,
    Day3,
}