using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerExample : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        //����Ƽ���� ������ ��Ű���� �ݵ�� ���̶�Ű�� �ö� �־���Ѵ�.
        // (static... -> �޸𸮿� �̸� �ö��ֱ� ����.)

        //Prefab�� ���ӿ�����Ʈ -> C# Object : ��� Ŭ������ �ֻ��� Ŭ���� 
        //�ֻ��� Ŭ���� -> GameObject : MonoBehaviour (����)
        //MonoBehaviour -> �������̹��� ���� : ���̶�Ű�� �ø� �� �ְ� ��.

        //���� �޸�(���̶�Ű)�� �ø� �� �ִ� �غ�
        //Resources ������ ����
        //��Ÿ�� ���߿� ������ �ʿ��� ��!
        GameObject target = Resources.Load<GameObject>("Clue Event Controller");

        Transform p = GameObject.Find("Managers").transform;

        //�޸�(���̶�Ű)�� �ø��� �ڵ�
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
