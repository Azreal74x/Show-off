using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    private GameObject instantiatePrefab = null; //the object that will be created
    private float lastSpawnTime; //variable to keep track of time passed
    [SerializeField] private float spawnDelay = 2f; //the delay between spawning of objects

    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>(); //create list for all possible spawnpoints
    [SerializeField] private List<GameObject> objectsPrefabs = new List<GameObject>(); //create list for the different object prefabs
    [SerializeField] private List<Material> materials = new List<Material>(); //create list for the different materials

    private void Start()
    {
        lastSpawnTime = Time.time; //set last spawn time to current time to keep track
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime >= spawnDelay)
        { //if time - last spawn time is bigger than time passed, so if this amount of time passed
            int randomObjectPrefab = Random.Range(0, objectsPrefabs.Count); //get random object from the prefabs list
            int randomSpawnPoint = Random.Range(0, spawnPoints.Count); //get random spawnpoint from the spawnpoints list
            int randomMaterial = Random.Range(0, materials.Count); //get random material from the materials list
            instantiatePrefab = Instantiate(objectsPrefabs[randomObjectPrefab], spawnPoints[randomSpawnPoint].transform.position, transform.rotation, transform); //instantiate the random object at random spawnpoint with current parent rotation as a child of what this script is attached to
            instantiatePrefab.GetComponent<Renderer>().material = materials[randomMaterial]; //assign material to the newly created object
            lastSpawnTime = Time.time; //set last spawn time to current time to keep track from this point on again
        }
    }
}
