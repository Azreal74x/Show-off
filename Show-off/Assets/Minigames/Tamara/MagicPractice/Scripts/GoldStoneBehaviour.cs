using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldStoneBehaviour : MonoBehaviour {

  private GoldStoneSpawner spawner;
  private GameObject spawnPoint;

  [SerializeField] private GameObject player;
  private bool moveToPlayer = false;
  [SerializeField] private float moveSpeed = 2f;

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
  }


  private void Update() {
    if (gameObject.name == "StoneCube(Clone)") {
      //Debug.Log("another stone cube");
    }

    if (gameObject.name == "GoldCube(Clone)" || gameObject.name == "GoldSphere(Clone)") {
      //Debug.Log("collided with gold");
    }

    if (moveToPlayer) {
      Vector3 direction = (player.transform.position - transform.position).normalized; //calculate direction to player
      transform.position += direction * moveSpeed * Time.deltaTime; //move towards player
    }
  }

  public void SetSpawner(GoldStoneSpawner spawner, GameObject spawnPoint) {
    this.spawner = spawner;
    this.spawnPoint = spawnPoint;
  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)

      if (spawner != null && spawnPoint != null) {
        spawner.EmptySpawn(spawnPoint);
      }

      if (collision.gameObject.tag == "Player") { //check if the collision was with the player by checking the tag
        //Debug.Log("Collided with player"); 
        Destroy(gameObject); //destroy the object this script is attached to
      }

      if (collision.gameObject.tag == "Bullet") { //check if the collision was with a bullet
        moveToPlayer = true;
      }

      if (collision.gameObject.tag == "Gold" || collision.gameObject.tag == "Stone") { //check if collision was with another piece of gold or stone
        Destroy(gameObject); //destroy the object this script is attached to
      }

    }
  }
}
