using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue         dialogue;

    public void Start(){ //awake ensures this occurs on start, which is when we change to this scene
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
