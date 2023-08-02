using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MovingCharacter
{
    static public PlayerManager instance;

    public string currentMapName; 

    private ClueManager theClue;

    //shift 키를 누른 경우 속도 빨라짐
    public float runSpeed;
    private float applyRunSpeed;
    //shift 키 자연스러운 이동
    private bool applyRunFlag = false;
    public bool transferMap= true;

    private bool canMove = true; //코루틴 반복 조건 변수

    public bool notMove=false;

    private bool imgevent= false;
    public int realimg=0;
    // private float imgeventDelay;
    // private float currentImgeventDelay;

    public GameObject playobject;
    public static int day=1; //현재 day
    public int enditemcount=0; //4일차 lab 미니게임 아이템 수집 개수
    private int[] enditem=new int[4]{0,0,0,0};
    public string ending="sad";
    private static bool isminigaming=false;

    public Vector2 start;
    public Vector2 end;
    RaycastHit2D hit;

    private Vector3 normalizedDir = Vector2.down;
    private float[] dirs = new float[2];
    

    private void Awake()
    {
        GameEventLinker.LinkerClear();
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
        theClue=FindObjectOfType<ClueManager>();
    }

    IEnumerator MoveCoroutine()
    {
        //방향키 눌렸을 때
        while(Input.GetAxisRaw("Vertical") !=0 || Input.GetAxisRaw("Horizontal")!=0 && !notMove && !imgevent)
        {
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

            //눌린값 vector에 저장
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
            //vector.x
            if(vector.x !=0)
                vector.y=0;

            Debug.Log(vector.x);
            SetDir(vector);

            //Animation
            //설정한 파라미터 값: DirX, DirY
            animator.SetFloat("DirX",vector.x);
            animator.SetFloat("DirY",vector.y);

            start =  transform.position; // a지점, 캐릭터의 현재 위치 값 
            end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);    //b지점, 캐릭터가 이동하고자하는 위치 값
            
            //Debug.Log(vector);
            //Debug.DrawLine(start,end, Color.red);
            hit=Physics2D.Linecast(start, end, layerMask);
            //RaycastHit2D hit= Physics2D.Raycast(this.transform.position, this.transform.forward, 30.0f,layerMask);

            if(hit.collider != null )
            {
                playobject = hit.collider.gameObject;
                break;
            }  
            else
            {
                //Debug.Log("NULLLL");
                playobject = null;
            }
            
            //상태 전이
            animator.SetBool("Walking",true);

            //48 픽셀 단위 움직임으로 전체 이동을 묶음
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
        }
        animator.SetBool("Walking",false); //walking 상태 원상복귀 -> Standing
        canMove=true; //방향키 처리 원상복귀

    }

    // Update is called once per frame
    void Update() //매 프레임마다 함수를 실행
    {     //위치 입력 받기 , 레이캐스트
        var objDetection = Physics2D.Linecast(transform.position, transform.position + normalizedDir * 50f, layerMask);
        Debug.DrawLine(transform.position, transform.position + normalizedDir * 100, Color.blue);
        //Debug.Log(normalizedDir);
        if (canMove && !notMove && !imgevent) //코루틴 반복 조건
        {
            if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") !=0)
            {
                canMove=false; //코루틴 반복 방지
                StartCoroutine(MoveCoroutine());
            }
        }


//멈췄을때 코루틴정지 -> playobject null ,동작x
        if (!notMove && !imgevent)
        {
            //Debug.Log(objDetection.collider);
            //아이템 이벤트 발생
            if (objDetection.collider != null && Input.GetKeyDown(KeyCode.Z))
            {
                //playobject = hit.collider.gameObject;
                Debug.Log(playobject);
                Debug.Log("z");
                imgevent = true;
                realimg = theClue.showimage(day, objDetection.collider.gameObject);
            }

            if(currentMapName == "lab" && objDetection.collider != null)
            {
                switch(objDetection.collider.gameObject.name)
                {
                    case "lab_log":
                        if(enditem[0]==0)
                            enditemcount++;
                        break;
                    case "lab_report1":
                        if(enditem[1]==0)
                            enditemcount++;
                        break;
                    case "computer":
                        if(enditem[2]==0)
                            enditemcount++;
                        break;
                    case "lab_report2":
                        if(enditem[3]==0)
                            enditemcount++;
                        break;
                    default:
                        break;
                }
            }

        }    

        if(imgevent)
        {
            Debug.Log(realimg);
            if(realimg == 0)
                imgevent= false;
            else if(realimg ==100)
            {
                notMove=true;
                // theClue.closeimage();
            }
            notMove=false;
            imgevent= false;
            realimg = 0;
        }

        //workspace 미니게임 실행
        if(currentMapName == "workspace" && day ==1 && !isminigaming )
        {
            isminigaming=true;
            if(!GameEventLinker.IsAvailable("workspace_minigame"))
            {
                Debug.Log("start minigame");
                StartCoroutine(minigame());
            }
        }

        //lab 미니게임 아이템 획득
        if(currentMapName == "lab")
        {
            
        }
    }

IEnumerator minigame()
{
    Instantiate(Resources.Load<GameObject>("LabMinigame"));
    yield return new WaitUntil(()=>GameEventLinker.IsAvailable("lab_minigame"));
    isminigaming=false;
}
    private void SetDir(Vector3 dir)
    {
        if (dir.magnitude <= 0.1f)
            return;

        dirs[0] = dir.x;
        dirs[1] = dir.y;

        float biggest = -1f;
        int idx = -1;
        for (int i = 0; i < dirs.Length; i++)
        {
            if (Mathf.Abs(dirs[i]) > biggest)
            {
                biggest = Mathf.Abs(dirs[i]);
                idx = i;
            }
        }
        biggest = dirs[idx];
        dirs[0] = idx == 0 ? biggest : 0;
        dirs[1] = idx == 1 ? biggest : 0;
        dir = new Vector3(dirs[0], dirs[1]);

        normalizedDir = dir.normalized;
        return;
    }
}
