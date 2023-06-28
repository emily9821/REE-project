using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{
    public float speed; //캐릭터의 스피드 담당
    public  int walkCount;
    protected int currentWalkCount;
    //private GameObject playobject;

    protected Vector3 vector; 
    
    public Animator animator;
    public BoxCollider2D boxCollider;
    public LayerMask layerMask; 
    public ClueManager theClue;

    
}
