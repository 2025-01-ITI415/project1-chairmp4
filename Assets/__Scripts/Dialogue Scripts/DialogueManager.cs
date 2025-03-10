using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
// First in first out data type
    private Queue<string>       sentences;

    public Text                 nameText;
    public Text                 dialogueText;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){

        nameText.text = dialogue.charactername;

        // Debug.Log("starting convo");

        sentences.Clear(); //removes previous dialogue

        foreach ( string sentence in dialogue.sentences ){
            sentences.Enqueue(sentence); //adds all dialogue in individual trigger section
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if ( sentences.Count == 0 ){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        // Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        // Debug.Log("End of convo");
        SceneManager.LoadScene("2_Main_Scene_Prechange"); //transitions to gameplay section
    }
}