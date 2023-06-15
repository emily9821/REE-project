using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerExample : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        //유니티에서 동작을 시키려면 반드시 하이라키에 올라가 있어야한다.
        // (static... -> 메모리에 미리 올라가있기 때문.)

        //Prefab도 게임오브젝트 -> C# Object : 모든 클래스의 최상위 클래스 
        //최상위 클래스 -> GameObject : MonoBehaviour (조건)
        //MonoBehaviour -> 모노비헤이버의 역할 : 하이라키에 올릴 수 있게 함.

        //단지 메모리(하이라키)에 올릴 수 있는 준비
        //Resources 폴더만 가능
        //런타임 도중에 에셋이 필요할 때!
        GameObject target = Resources.Load<GameObject>("Clue Event Controller");

        Transform p = GameObject.Find("Managers").transform;

        //메모리(하이라키)에 올리는 코드
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
