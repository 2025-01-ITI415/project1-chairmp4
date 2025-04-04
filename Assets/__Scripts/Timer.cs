using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] float         remainingTime;
    [SerializeField] float         startingTime;
    [SerializeField] Text          timerText; //enables input in inspector
    // Update is called once per frame

    void ResetTimer(){
        remainingTime = startingTime;
    }
    void Update()
    {
        if ( Input.anyKeyDown ){
            ResetTimer();
            // Debug.Log(remainingTime);
            // Debug.Log(startingTime);
        }
        if ( remainingTime > 0 ){
            remainingTime -= Time.deltaTime;
        }
        // Checks to see if no inputs and remaining time is less than zero
        else if ( !Input.anyKeyDown && remainingTime < 0 ){
            SceneManager.LoadScene("0_Start_Screen"); //reloads game
        }

        int minutes = Mathf.FloorToInt( remainingTime / 60 );
        int seconds = Mathf.FloorToInt ( remainingTime % 60 );
        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
    }
}
