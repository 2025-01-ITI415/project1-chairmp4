using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // creating variable for controlling in inspector
    public float                speed = 0;
    private Rigidbody           rb;
    private int                 count;
    private float               movementX;
    private float               movementY;
    public float                rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        // adds Rigidbody component to rb variable for player movemenet
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // creating a function using InputSystem Unity package
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        if ( Mathf.Abs(movementY) < 0.01f )
        {
            movementY = 0;
        }
        else 
        {
            movementY = movementY + 1;
            movementY = movementY / 2f;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        movement.Normalize();
        
        rb.velocity = movement * speed; 

        // enables player rotation upon input
        if (movement != Vector3.zero){
            // transform.forward = movement;
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            rb.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
         }
    }
    
    public void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
        }

        count = count + 1;
        Debug.Log("count went up");

        if ( count <= 1 ){
            SceneManager.LoadScene("4_End_Screen_Win");
        }
    }
}
