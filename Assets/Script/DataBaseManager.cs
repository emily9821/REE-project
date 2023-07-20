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

    //day 별 아이템 이미지 정보 리스트
    public List<ImgItem> itemList1 = new List<ImgItem>();
    public List<ImgItem> itemList2 = new List<ImgItem>();
    public List<ImgItem> itemList3 = new List<ImgItem>();
    public List<ImgItem> itemList4 = new List<ImgItem>();
    public List<ImgItem> itemList5 = new List<ImgItem>();

    // Start is called before the first frame update
    void Start()
    {
        itemList1.Add(new ImgItem("room1신문기사", 210 , "신문 기사가 올려져 있다", ImgItem.ImgDate.day1 ,1 ));
        itemList1.Add(new ImgItem("workspace메모지", 220 , "카를, 키패드를 교체해놨어 새 비밀번호는 그날이야 -by 파벨", ImgItem.ImgDate.day1,1));
        itemList1.Add(new ImgItem("workspace형제사진", 230 , "카를의 셀피 옆에 누군가 있는듯하다", ImgItem.ImgDate.day1,1));
        itemList1.Add(new ImgItem("outview", 250 , "평소와 다를것없는 G구역의 풍경", ImgItem.ImgDate.day1,1));
        // itemList.Add(new ImgItem("", 210 , "신문 기사가 올려져 있다", day2,1));
    }

}
