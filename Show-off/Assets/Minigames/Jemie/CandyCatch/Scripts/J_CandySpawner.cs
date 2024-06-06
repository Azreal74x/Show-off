using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_CandySpawner : MonoBehaviour {

  private GameObject instantiatePrefab = null; //the object that will be created
  private float lastSpawnTime; //variable to keep track of time passed

  [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>(); //create list for all possible spawnpoints
  [SerializeField] private List<GameObject> objectsPrefabs = new List<GameObject>(); //create list for the different object prefabs
  //[SerializeField] private List<Material> materials = new List<Material>(); //create list for the different materials

  private float startDelay = 2f; //the starting amount for spawning delay
  [SerializeField] private float delay = 0f; //the actual delay in between spawning

  [SerializeField] private float spawnDecreaseSpeed = 0.04f; //how fast the spawn increase happens
  [SerializeField] private float minDelay = 0.5f; //minimum delay time

  [SerializeField] private float fallSpeed = 1f;
  [SerializeField] private float fallIncreaseSpeed = 0.1f;
  [SerializeField] private float maxFallSpeed = 7f;

  private float elapsedTime; //custom timer to keep track of when scene started

  private void Start() {
    lastSpawnTime = Time.time; //set last spawn time to current time to keep track
    elapsedTime = 0f; //set custom timer to 0
  }

  private void Update() {
    elapsedTime += Time.deltaTime; //update the custom timer
    delay = startDelay - elapsedTime * spawnDecreaseSpeed; //slowly decrease the spawning delay
    if (delay <= minDelay) { //if delay is smaller than or equal to minDelay
      delay = minDelay; //if delay is lower than minimum set it to minimum
    }

    fallSpeed += fallIncreaseSpeed * Time.deltaTime; //increase fallspeed
    if (fallSpeed > maxFallSpeed) {
      fallSpeed = maxFallSpeed; //clamp the fall speed to maxFallSpeed
    }

    if (Time.time - lastSpawnTime >= delay) { //if time - last spawn time is bigger than time passed, so if this amount of time passed
      int randomObjectPrefab = Random.Range(0, objectsPrefabs.Count); //get random object from the prefabs list
      int randomSpawnPoint = Random.Range(0, spawnPoints.Count); //get random spawnpoint from the spawnpoints list
      //int randomMaterial = Random.Range(0, materials.Count); //get random material from the materials list
      instantiatePrefab = Instantiate(objectsPrefabs[randomObjectPrefab], spawnPoints[randomSpawnPoint].transform.position, transform.rotation, transform); //instantiate the random object at random spawnpoint with current parent rotation as a child of what this script is attached to
      //instantiatePrefab.GetComponent<Renderer>().material = materials[randomMaterial]; //assign material to the newly created object
      instantiatePrefab.GetComponent<J_Candy>().fallSpeed = fallSpeed;
      lastSpawnTime = Time.time; //set last spawn time to current time to keep track from this point on again
    }
  }
}
