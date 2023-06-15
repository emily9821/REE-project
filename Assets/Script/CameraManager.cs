using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;
    
    //카메라가 따라갈 대상
    public GameObject target;
    //카메라가 얼마나 빠른 속도록 대상을 따라갈건지
    public float moveSpeed;
    private Vector3 targetPosition; //대상의 현재 위치

    public BoxCollider2D bound;
    //박스 커라이더 영역의 최소 최대 xyz 값을 지님
    private Vector3 minBound;
    private Vector3 maxBound;
    
    //카메라의 반너비, 반높이 값을 지닐 변수
    private float halfWidth;
    private float halfHeight;
    
    //카메라의 반높이 값을 구할 속성을 이용하기 위한 변수
    private Camera theCamera;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        } 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        theCamera=GetComponent<Camera>();
        minBound=bound.bounds.min;
        maxBound=bound.bounds.max;
        halfHeight=theCamera.orthographicSize;
        halfWidth=halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        //카메라는 캐릭터를 따라다니기 때문에 매프레임마다 생성되는 update 함수에 작성해야함
        if(target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            //this -> 이 스크립트가 적용될 객체 -> 카메라임  this는 생략 가능

            this.transform.position =  Vector3.Lerp(this.transform.position,targetPosition, moveSpeed * Time.deltaTime);
            //lerp : a값과 b값사이의 선형 보간으로 중간 값을 리턴한다.
            //벡터 a 에서 벡터 b까지 t의 속도로 움직이게 하는 것
            //ex) (1,10,0.5f) = 5   (5,10,0.5f) = 7.5
            //Time.deltaTime :  1초에 실행되는 프레임의 역수 .1초에 60 프레임이 실행된다면, 60 분의 1값을 지님.
            //1초에 moveSpeed 만큼 이동

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x+halfWidth,maxBound.x-halfWidth);
            float clampedY= Mathf.Clamp(this.transform.position.y, minBound.y+halfHeight,maxBound.y-halfHeight);
        
            this.transform.position = new Vector3(clampedX,clampedY, this.transform.position.z);
        }
    }

    public void SetBound(BoxCollider2D newBound)
    {
        bound=newBound;
        minBound= bound.bounds.min;
        maxBound=bound.bounds.max;

    }
}
