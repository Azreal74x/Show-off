using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ObjectBehaviour : MonoBehaviour {

  [SerializeField] private int score = 0;

  private void Start() {

  }

  private void Update() {

  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)
      if (collision.gameObject.tag == "Player") { //check if the collision was with the player by checking the tag
        Debug.Log("Collided with player"); //place for behaviour such as +1 to the total score of caught objects
      }
      Destroy(gameObject); //destroy the object this script is attached to
    }
  }
}
