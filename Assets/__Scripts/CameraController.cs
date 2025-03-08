using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject       car;
    private Vector3         offset;
    // Start is called before the first frame update
    void Start()
    {
        // calcuates initial difference between camera and gameObj
        offset = transform.position - car.transform.position;
    }

    // Late Update is called after the player momvement happens on Update
    void LateUpdate()
    {
        // aligns camera to game option, matching position
        transform.position = car.transform.position + offset;
    }
}
