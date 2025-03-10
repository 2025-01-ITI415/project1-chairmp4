using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // creating variable for controlling in inspector
    public float                speed = 0;
    private Rigidbody           rb;
    private float               movementX;
    private float               movementY;
    public float               rotationSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {
        // adds Rigidbody component to rb variable for player movemenet
        rb = GetComponent<Rigidbody>();
    }

    // creating a function using InputSystem Unity package
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        movement.Normalize();
        
       // rb.AddForce(movement * speed); trying to find out how to reapply rb w/ transform to enable drag and bring back collision
        transform.Translate(movement * speed * Time.deltaTime, Space.World);  

        // enables player rotation upon input
        if (movement != Vector3.zero){
            transform.forward = movement;
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
    }
}
