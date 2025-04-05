using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Reference to the DialogueManager
    public DialogueManager dialogueManager;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (dialogueManager != null && dialogueManager.gameObject.activeInHierarchy)
        {
            return;  // Skip input processing if the DialogueManager is active
        }
        
        // Check for Enter key to simulate "Menu" button press
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.M))
        {
            TitleButtonPressed();
        }

        // Check for Space key to simulate "Return" button press
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.N))
        {
            NextButtonPressed();
        }

        if (Input.GetKeyDown(KeyCode.Backslash) || Input.GetKeyDown(KeyCode.B))
        {
            RestartButtonPressed();
        }
    }

    void TitleButtonPressed()
    {
        LoadScene("0_Start_Screen");
    }
    void NextButtonPressed()
    {
        LoadScene("1_Dialogue_Scene");
    }
    void RestartButtonPressed()
    {
        LoadScene("1_Dialogue_Scene");
    }
}