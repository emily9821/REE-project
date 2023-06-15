using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 주석 추가

public class TransferMap : MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름


    private PlayerManager thePlayer; //생성
    private FadeManager theFade;
    private OrderManager theOrder;
    public bool flag;
    

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        //GetComponent 단일객체
        //FindObjectOfType 모든 객체
        theFade = FindObjectOfType<FadeManager>();
        theOrder= FindObjectOfType<OrderManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            thePlayer.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
        }
    }

}


