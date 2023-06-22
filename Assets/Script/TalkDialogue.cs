using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;

    private DialogueManager theDM;

    // Start is called before the first frame update
    void Start()
    {
        theDM= FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            theDM.ShowDialogue(dialogue);
        }
    }

    void Update()
    {
       
    }
}
