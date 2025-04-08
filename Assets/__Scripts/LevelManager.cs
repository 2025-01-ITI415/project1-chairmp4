using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public DialogueManager       dialogueManager;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

      void Update()
    {
        
        // finds script component within dialogueManager asset
        dialogueManager.GetComponent<DialogueManager>();

        if (dialogueManager.gameObject.activeInHierarchy)
        {
            return;  // skips rest of inputs in update if gameobject is present
        }
        
        // Return to title screen, 4_End_Screen
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.JoystickButton2) ) //BL
        {
            TitleButtonPressed();
        }

        // Begin Gameplay, 0_Start_Screen
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton1)) //TR
        {
            NextButtonPressed();
        }

        // Return to gameplay, 4_End_Screen
        if (Input.GetKeyDown(KeyCode.Backslash) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.JoystickButton3)) //BR
        {
            RestartButtonPressed();
        }
    }

    // Return to title screen
    void TitleButtonPressed()
    {
        LoadScene("0_Start_Screen");
    }
    // Begin Gameplay
    void NextButtonPressed()
    {
        LoadScene("1_Dialogue_Scene");
    }

    // Return to gameplay
    void RestartButtonPressed()
    {
        LoadScene("1_Dialogue_Scene");
    }
}