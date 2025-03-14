using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // enables rotation to be edited in the inspector
    public GameObject   collectiblePrefab;
    public Vector3[]    exceptionRange;
    public float        rotationX;
    public float        rotationY;
    public float        rotationZ;
    public float        spawnTotal;
    // Update is called once per frame

    void Start()
    {   
        // setting range for random spawn: X, Y, Z
        Vector3 randomSpawnPosition = new Vector3(Random.Range(19, 154), -9, Random.Range(-54, 75));
        Instantiate(collectiblePrefab, randomSpawnPosition, Quaternion.identity);
    }

    void Update()
    {
        transform.Rotate (new Vector3 (rotationX, rotationY, rotationZ) * Time.deltaTime);
    }
}
