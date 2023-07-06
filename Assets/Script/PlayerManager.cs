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
    public bool transferMap = true;

    private bool canMove = true; //코루틴 반복 조건 변수
    public bool notMove = false;

    private GameObject playobject;

    Vector2 start;
    Vector2 end;
    RaycastHit2D hit;

    float x, y;
    Rigidbody2D rigid;
    Vector3 dirVec;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject); //맵이 이동해도 캐릭터 유지
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
<<<<<<< HEAD
        rigid=GetComponent<Rigidbody2D>();
=======
        rigid = GetComponent<Rigidbody2D>();
>>>>>>> 069436597c9601d325f9f9becfdea59b23db3ca7
    }


    // Update is called once per frame
    void Update() //매 프레임마다 함수를 실행
    {     //위치 입력 받기 , 레이캐스트
<<<<<<< HEAD
    
        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        
        //vector.x
        if(vector.x !=0)
            vector.y=0;
        
        //Animation
        animator.SetFloat("DirX",vector.x);
        animator.SetFloat("DirY",vector.y);

        if(vector.x !=0 || vector.y !=0)
        {
            canMove= true;
            animator.SetBool("Walking",true); 
        }
        else
        {
            canMove=false;
            animator.SetBool("Walking",false);
            animator.SetFloat("DirX",x);
            animator.SetFloat("DirY",y);
            Debug.Log(vector);
=======

        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

        //vector.x
        if (vector.x != 0)
            vector.y = 0;

        //Animation
        animator.SetFloat("DirX", vector.x);
        animator.SetFloat("DirY", vector.y);

        if (vector.x != 0 || vector.y != 0)
        {
            canMove = true;
            animator.SetBool("Walking", true);
        }
        else
        {
            canMove = false;
            animator.SetBool("Walking", false);
            animator.SetFloat("DirX", x);
            animator.SetFloat("DirY", y);
            Debug.Log(vector);
        }

        //Direction
        if (x == 1)
            dirVec = Vector3.up;
        else if (x == -1)
            dirVec = Vector3.down;
        else if (y == -1)
            dirVec = Vector3.left;
        else if (y == 1)
            dirVec = Vector3.right;

        //shift키 속도 빠르게
        if (Input.GetKey(KeyCode.LeftShift))
        {
            applyRunSpeed = runSpeed;
            applyRunFlag = true;
        }
        else
        {
            applyRunSpeed = 0;
            applyRunFlag = false;
>>>>>>> 069436597c9601d325f9f9becfdea59b23db3ca7
        }
            
        //Direction
        if(x ==1)
            dirVec=Vector3.up;
        else if(x ==-1)
            dirVec=Vector3.down;
        else if(y ==-1)
            dirVec=Vector3.left;
        else if(y ==1)
            dirVec=Vector3.right;

<<<<<<< HEAD
        //shift키 속도 빠르게
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
        
    }

    void FixedUpdate()
    {
        //위치 결과로 애니메이션
        //start =  transform.position;
        //end = start +new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);

       if(canMove)
       {
            //전체 이동
            //x축
            if(vector.x!=0)
            {
                transform.Translate(vector.x*(speed+applyRunSpeed),0,0);
                x=vector.x;
                y=0;
            }
            //y축
            else if(vector.y!=0)
            {   
                transform.Translate(0,vector.y*(speed+applyRunSpeed),0);
                y=vector.y;
                x=0;
            }
            if(applyRunFlag)
            {
                currentWalkCount ++; //shift 키 두번 증가
            }
            else
            {
                currentWalkCount = 0 ;
            }
            
       }
        start =  transform.position;
        end= dirVec * 1f;
        //rigid.velocity=start*speed;
        //레이캐스트
        Debug.DrawRay(start, end, Color.red);
        hit=Physics2D.Linecast(start,end, layerMask);
        if(hit.collider != null )
        {
            playobject=hit.collider.gameObject;
            Debug.Log(playobject);
            //theOM.Action(playobject);
            /*if(Input.GetKey(KeyCode.Z))
                {
                    canMove=false;
                    Debug.Log("z");
                    theClue.Action(playobject);  
                }*/
        }  
        else
            playobject=null;
    }
=======
    }

    void FixedUpdate()
    {
        //위치 결과로 애니메이션
        //start =  transform.position;
        //end = start +new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);

        if (canMove)
        {
            //전체 이동
            //x축
            if (vector.x != 0)
            {
                transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
                x = vector.x;
                y = 0;
            }
            //y축
            else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
                y = vector.y;
                x = 0;
            }
            if (applyRunFlag)
            {
                currentWalkCount++; //shift 키 두번 증가
            }
            else
            {
                currentWalkCount = 0;
            }
>>>>>>> 069436597c9601d325f9f9becfdea59b23db3ca7

        }
        start = transform.position;
        end = dirVec * 1f;
        //rigid.velocity=start*speed;
        //레이캐스트
        Debug.DrawRay(start, end, Color.red);
        hit = Physics2D.Linecast(start, end, layerMask);
        if (hit.collider != null)
        {
            playobject = hit.collider.gameObject;
            Debug.Log(playobject);
            //theOM.Action(playobject);
            /*if(Input.GetKey(KeyCode.Z))
                {
                    canMove=false;
                    Debug.Log("z");
                    theClue.Action(playobject);  
                }*/
        }
        else
            playobject = null;
    }

}