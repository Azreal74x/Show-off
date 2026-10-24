using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BulletBehaviour : MonoBehaviour {

  [SerializeField] private float bulletSpeed = 2f;

  private float lastSpawnTime; //variable to keep track of time passed
  [SerializeField] private float lifetime = 5f; //the delay between spawning of objects

  GameObject player; //reference to Player obj
  T_Score T_Score; //reference to ScoreBehaviour script

  private void Start() {
    lastSpawnTime = Time.time; //set last spawn time to current time to keep track
    player = GameObject.FindGameObjectWithTag("Player"); //find player by its tag
    T_Score = player.GetComponent<T_Score>();
  }

  private void Update() {
    transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime, Space.Self); //make bullet move forward in correct direction (local space) from the beam 

    if (Time.time - lastSpawnTime >= lifetime) { //if time - last spawn time is bigger than time passed, so if this amount of time passed
      Destroy(gameObject); //destroy the object this script is attached to
      lastSpawnTime = Time.time; //set last spawn time to current time to keep track from this point on again
    }

  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)
      if (collision.gameObject.tag == "GoodCandy") { //startDelay if the collision was with a gold by checking the tag
        //Debug.Log("Collided with gold");
      }
      else if (collision.gameObject.tag == "BadCandy") { //startDelay if the collision was with a stone by checking the tag
        //Debug.Log("Collided with gold");
      }
      else if(collision.gameObject.tag == "Kill") {
        if (T_Score != null) {
          T_Score.canMove = true;
        }
        else {
          Debug.Log("T_Score is null");
        }
      }
      Destroy(gameObject); //destroy the object this script is attached to
    }
  }
}
