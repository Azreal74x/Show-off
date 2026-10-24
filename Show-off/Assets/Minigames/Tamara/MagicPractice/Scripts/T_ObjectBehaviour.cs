using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_ObjectBehaviour : MonoBehaviour {

  private T_ObjectSpawner spawner;
  private GameObject spawnPoint;

  [SerializeField] private GameObject player;
  private bool moveToPlayer = false;
  [SerializeField] private float moveSpeed = 2f;

  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
  }


  private void Update() {
    if (moveToPlayer) {
      Vector3 direction = (player.transform.position - transform.position).normalized; //calculate direction to player
      transform.position += direction * moveSpeed * Time.deltaTime; //move towards player
    }
  }

  public void SetSpawner(T_ObjectSpawner spawner, GameObject spawnPoint) {
    this.spawner = spawner;
    this.spawnPoint = spawnPoint;
  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)

      if (spawner != null && spawnPoint != null) {
        spawner.EmptySpawn(spawnPoint);
      }

      if (collision.gameObject.tag == "Player") { //startDelay if the collision was with the player by checking the tag
        //Debug.Log("Collided with player"); 
        Destroy(gameObject); //destroy the object this script is attached to
      }

      if (collision.gameObject.tag == "Bullet") { //startDelay if the collision was with a bullet
        moveToPlayer = true;
      }

      if (collision.gameObject.tag == "GoodCandy" || collision.gameObject.tag == "BadCandy") { //startDelay if collision was with another piece of gold or stone
        Destroy(gameObject); //destroy the object this script is attached to
      }

    }
  }
}
