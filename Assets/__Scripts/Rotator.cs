using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // enables rotation to be edited in the inspector
    public float        rotationX;
    public float        rotationY;
    public float        rotationZ;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (rotationX, rotationY, rotationZ) * Time.deltaTime);
    }
}
