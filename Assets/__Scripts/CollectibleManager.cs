using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    // enables rotation to be edited in the inspector
    public GameObject   collectiblePrefab;
    [SerializeField] public GameObject[]    SpawnPoints;
    public float        rotationX;
    public float        rotationY;
    public float        rotationZ;

    // Update is called once per frame
    void Start()
    {   
        {
            int randomIndex = Random.Range(0, SpawnPoints.Length);
            Debug.Log(randomIndex); // Relays index number into console

            // Ensures no IndexOutOfRangeException error by checking value
            if ( SpawnPoints.Length > 0 )
            {
                // Sets spawn location to randomIndex value called
                Vector3 randomSpawnPosition = SpawnPoints[randomIndex].transform.position;
                
                // Spawns random spawn location
                Instantiate(collectiblePrefab, randomSpawnPosition, Quaternion.identity);
            }
                
        }
    }

    void Update()
    {
        // Adds rotation to collectible asset that can be edited within the inspector
        transform.Rotate (new Vector3 (rotationX, rotationY, rotationZ) * Time.deltaTime);
    }
}
