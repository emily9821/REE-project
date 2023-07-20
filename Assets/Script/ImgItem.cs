using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImgItem 
{
    public string imgname; //이미지 이름
    public int imgid; //이미지 아이디 (현재는 object id로 일치시켜놓음)
    public string imgDescription; //이미지 설명 (대사창 나옴)
    public int imgCount; // 하나의 object에 있는 이미지 개수
    public Sprite imgIcon; //이미지 스프라이트
    public ImgDate imgDate; //이미지의 해당 날짜 date

    public enum ImgDate
    {
        day1=1,
        day2=2,
        day3=3,
        day4=4,
        day5=5
    } 

    public ImgItem(string _imgname,int _imgid, string _imgDes, ImgDate _imgDate, int _imgCount=1)
    {
        imgname= _imgname;
        imgid= _imgid;
        imgDescription= _imgDes;
        imgCount = _imgCount;
        imgDate=_imgDate;
        imgIcon= Resources.Load("ItemImg/"+_imgname, typeof(Sprite)) as Sprite;
    }

}