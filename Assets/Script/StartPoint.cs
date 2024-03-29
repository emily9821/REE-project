using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; //맵이 이동시, 플레이어가 시작될 위치
    private string currentMapName;
    private PlayerManager thePlayer;
    private CameraManager theCamera;

    // Start is called before the first frame update
    private void OnEnable() //start보다 먼저 실행
    {
        theCamera= FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerManager>();

        if(startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
