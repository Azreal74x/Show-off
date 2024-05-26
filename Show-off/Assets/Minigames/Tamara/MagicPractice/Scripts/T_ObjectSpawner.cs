using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_ObjectSpawner : MonoBehaviour
{
  private GameObject instantiatePrefab = null; //the object that will be created
  private float lastSpawnTime; //variable to keep track of time passed
  [SerializeField] private float spawnDelay = 2f; //the delay between spawning of objects

  [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>(); //create list for all possible spawnpoints
  [SerializeField] private List<GameObject> objectsPrefabs = new List<GameObject>(); //create list for the different object prefabs
  
  private Dictionary<GameObject, bool> spawnTaken = new Dictionary<GameObject, bool>(); //create dictionary to check if the spawn is empty

  [SerializeField] GameObject player; //reference to Player obj
  T_Score scoreBehaviour; //reference to ScoreBehaviour script

  private void Start() {
    lastSpawnTime = Time.time; //set last spawn time to current time to keep track

    foreach (var spawn in spawnPoints) { //for every spawn in spawnPoints
      spawnTaken[spawn] = false; //mark them all as false / not taken
    }

    scoreBehaviour = player.GetComponent<T_Score>(); //get ScoreBehaviour script from Player obj
  }

  private void Update() {
    if (Time.time - lastSpawnTime >= spawnDelay && scoreBehaviour.canMove) { //if time - last spawn time is bigger than time passed, so if this amount of time passed and the beam is moving again
      int randomObjectPrefab = Random.Range(0, objectsPrefabs.Count); //get random object from the prefabs list

      GameObject spawn = GetEmptySpawn(); 

      if (spawn != null) {
        instantiatePrefab = Instantiate(objectsPrefabs[randomObjectPrefab], spawn.transform.position, transform.rotation, transform); // instantiate the random object at random spawnpoint with current parent rotation as a child of what this script is attached to
        spawnTaken[spawn] = true; // mark this spawn point as occupied
        instantiatePrefab.GetComponent<T_ObjectBehaviour>().SetSpawner(this, spawn); // set the spawner and spawn point in the GoldBehaviour script
        lastSpawnTime = Time.time; // set last spawn time to current time to keep track from this point on again
      }
    }
  }

  private GameObject GetEmptySpawn() {
    List<GameObject> unoccupiedSpawnPoints = new List<GameObject>();

    foreach (var spawn in spawnPoints) {
      if (!spawnTaken[spawn]) {
        unoccupiedSpawnPoints.Add(spawn);
      }
    }

    if (unoccupiedSpawnPoints.Count > 0) {
      int randomIndex = Random.Range(0, unoccupiedSpawnPoints.Count);
      return unoccupiedSpawnPoints[randomIndex];
    }

    return null;
  }

  public void EmptySpawn(GameObject spawnPoint) {
    if (spawnTaken.ContainsKey(spawnPoint)) {
      spawnTaken[spawnPoint] = false; 
    }
  }
}
