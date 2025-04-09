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
    public Animator             RoverAnimator;
    private Dialogue            currentDialogue;
    private int                 sentenceIndex = 0;

    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){

        currentDialogue = dialogue;

        nameText.text = dialogue.charactername;

        // Debug.Log("starting convo");

        sentences.Clear(); //removes previous dialogue

        foreach ( string sentence in dialogue.sentences ){
            sentences.Enqueue(sentence); //adds all dialogue in individual trigger section
        }

        sentenceIndex = 0;
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

        TriggerAnimations(sentenceIndex);

        sentenceIndex++;

    }

    private void TriggerAnimations(int index)
    {
        if (currentDialogue != null && currentDialogue.triggerName != null && currentDialogue.triggerName.Length > index)
        {
            string trigger = currentDialogue.triggerName[index]; // Get the trigger for the current sentence
            RoverAnimator.SetTrigger(trigger); // Trigger the animation for the current sentence

            Debug.Log(trigger);
    }
}

    void EndDialogue(){
        // Debug.Log("End of convo");
        SceneManager.LoadScene("2_Main_Scene_Prechange"); //transitions to gameplay section
    }
    void Update()
    {
        // Check for space key to display next sentence
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton3)) // BR
        {
            DisplayNextSentence();
            TriggerAnimations(sentenceIndex);
        }

        // Check for enter key to end the dialogue
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton2)) //BL 
        {
            EndDialogue();
        }
    }
}