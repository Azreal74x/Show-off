using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBehaviour : MonoBehaviour {

  private GoldStoneSpawner spawner;
  private GameObject spawnPoint;

  void Start() {

  }


  void Update() {
    if (gameObject.name == "StoneCube(Clone)") {
      //Debug.Log("another stone cubce");
    
    }
  }

  public void SetSpawner(GoldStoneSpawner spawner, GameObject spawnPoint) {
    this.spawner = spawner;
    this.spawnPoint = spawnPoint;
  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)
      /*if (collision.gameObject.tag == "Player") { //check if the collision was with the player by checking the tag
        Debug.Log("Collided with player"); //place for behaviour such as +1 to the total score of caught objects
      }*/

      if (spawner != null && spawnPoint != null) {
        spawner.EmptySpawn(spawnPoint);
      }

      if (gameObject.name == "StoneCube(Clone)") {
        Debug.Log("collided with stone cube");
      }

      Destroy(gameObject); //destroy the object this script is attached to
    }
  }
}
