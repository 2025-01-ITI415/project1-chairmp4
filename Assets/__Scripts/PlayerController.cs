using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    // creating variable for controlling in inspector
    // public float                speed = 0;
    private Rigidbody           rb;
    private int                 count;
    public PlayableDirector     HitCS;
    // private float               movementX;
    // private float               movementY;
    // public float                rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // adds Rigidbody component to rb variable for player movemenet
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // PREVIOUS INPUT SYSTEM!
    // // creating a function using InputSystem Unity package
    // void OnMove(InputValue movementValue)
    // {
    //     Vector2 movementVector = movementValue.Get<Vector2>();

    //     movementX = movementVector.x;
    //     movementY = movementVector.y;
    //     if ( Mathf.Abs(movementY) < 0.01f )
    //     {
    //         movementY = 0;
    //     }
    //     else 
    //     {
    //         movementY = movementY + 1;
    //         movementY = movementY / 2f;
    //     }
    // }

    // void FixedUpdate()
    // {
    //     Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    //     movement.Normalize();
        
    //     rb.velocity = movement * speed; 

    //     // enables player rotation upon input
    //     if (movement != Vector3.zero){
    //         //transform.forward = movement;
    //         Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

    //         rb.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    //      }
    // }
    
    public void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
        }
        else //for colliders that are not pickup trigger events
        {
            return; //prevents count from going up, bypasses this script
        }

        // Using pickup tag regardless of scene, but want to send player to certain
        // Locations depending on their state. Doing so with scene checks
        Scene activescene = SceneManager.GetActiveScene();

        // Checks if we are currently in prechange world
        if ( activescene.name == "2_Main_Scene_Prechange" )
        {
            count = count + 1;
            Debug.Log("count went up");

            if ( count <= 1 )
            {
                HitCS.stopped += OnTimelineStopped;
                HitCS.Play();
            }
        }

        if ( activescene.name == "3_Main_Scene_Postchange" )
        {
            SceneManager.LoadScene("4_Dialogue_Post");
        }


    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        HitCS.stopped -= OnTimelineStopped;

        SceneManager.LoadScene("3_Main_Scene_Postchange");
    }
}
