using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MovingCharacter
{
    static public PlayerManager instance;

    public string currentMapName; 

    //public ClueManager theClue;

    //shift 키를 누른 경우 속도 빨라짐
    public float runSpeed;
    private float applyRunSpeed;
    //shift 키 자연스러운 이동
    private bool applyRunFlag = false;
    public bool transferMap= true;

    private bool canMove = true; //코루틴 반복 조건 변수
    public bool notMove=false;

    private GameObject playobject;

    public Vector2 start;
    public Vector2 end;
    RaycastHit2D hit;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject); //맵이 이동해도 캐릭터 유지
            instance=this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        boxCollider =GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update() //매 프레임마다 함수를 실행
    {     //위치 입력 받기 , 레이캐스트
    
       vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        //vector.x
        if(vector.x !=0)
            vector.y=0;
            
        //Animation
        //설정한 파라미터 값: DirX, DirY
        animator.SetFloat("DirX",vector.x);
        animator.SetFloat("DirY",vector.y);

        start =  transform.position; // a지점, 캐릭터의 현재 위치 값 
        end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);    //b지점, 캐릭터가 이동하고자하는 위치 값

        Debug.Log(vector);
        Debug.DrawRay(start,end, Color.red);
        hit=Physics2D.Linecast(start,end, layerMask);

        if(hit.collider != null)
        {
            playobject=hit.collider.gameObject;
            Debug.Log(playobject);
            if(Input.GetKey(KeyCode.Z))
            {
                canMove=false;
                Debug.Log("z");
                theClue.Action(playobject);  
            }
        }
        else
        {
            playobject=null;
        }

    }

    void FixedUpdate()
    {
        //위치 결과로 애니메이션
        //boxCollider.enabled=true;

        if(Input.GetKey(KeyCode.LeftShift))
        {
        applyRunSpeed = runSpeed;
        applyRunFlag = true;
        }
        else
        {
            applyRunSpeed=0;
            applyRunFlag = false;
        }

        while(currentWalkCount < walkCount) 
        {
            //전체 이동하는 조건들
            //x축
            if(vector.x !=0)
            {
                transform.Translate(vector.x*(speed+applyRunSpeed),0,0);
            }
            //y축
            else if(vector.y !=0)
            {
                transform.Translate(0,vector.y*(speed+applyRunSpeed),0);
            }                
            if(applyRunFlag)
            {
                currentWalkCount ++; //shift 키 두번 증가
            }
            currentWalkCount ++; // 탈출하기 위한 조건 덧셈
            yield return new WaitForSeconds(0.01f); // 2.4픽셀씩 움직이는 과정 보여주기 위함
        }
            
        currentWalkCount = 0 ; //초기화  
        animator.SetBool("Walking",false); //walking 상태 원상복귀 -> Standing
        canMove=true; //방향키 처리 원상복귀

}
