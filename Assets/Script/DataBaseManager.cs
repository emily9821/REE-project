using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    //1. 씬 이동. A(이벤트 true flase) <-> B ---> database, 어떤 변수의 값이 true, false (전역 변수)
    //2. 세이브와 로드
    // 3. 미리 만들면 편하다. 아이템

    //변수
    public string[] var_name;
    public float[] var;
    //true, false 기억
    public string[] switch_name;
    public bool[] switches;

    //아이템

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
