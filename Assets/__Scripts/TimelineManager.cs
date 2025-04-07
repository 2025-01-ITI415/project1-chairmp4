using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector     playableDirector;
    public GameObject           inputManager;

    private bool                activePlayer = false;

    // Update is called once per frame
    void Update()
    {
        bool isPlaying = playableDirector.state == PlayState.Playing;

        if ( isPlaying != activePlayer )
        {
            activePlayer = isPlaying;

            if ( isPlaying )
            {
                DisableInput();
            }
            else
            {
                EnableInput();
            }
        }
    }

    private void DisableInput()
    {
        inputManager.SetActive(false);
    }

    private void EnableInput()
    {
        inputManager.SetActive(true);
    }
}
