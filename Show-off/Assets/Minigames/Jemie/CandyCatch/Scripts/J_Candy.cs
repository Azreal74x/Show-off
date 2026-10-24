using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class J_Candy : MonoBehaviour {

  [SerializeField] public float fallSpeed = 1f; //public so can be set to go faster from other scripts
  [SerializeField] private float torqueSpeed = 0.5f;
  private Rigidbody rb; //reference to rigidbody
  private float torqueDirection; //float to pick random torque direction

  private void Start() {
    rb = GetComponent<Rigidbody>(); //assign rigidbody

    if (Random.Range(0, 2) == 0) { //pick a random number to get random torque direction
      torqueDirection = 1; //spin to the right
    }
    else {
      torqueDirection = -1; //spin to the left
    }
  }

  private void Update() {

  }

  private void FixedUpdate() {
    transform.position -= new Vector3(0, Time.deltaTime * fallSpeed, 0); //make candy fall down
    rb.AddTorque(0, 0, torqueDirection * Time.deltaTime * torqueSpeed); //make candy spin
  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)
      /*if (collision.gameObject.tag == "Player") { //startDelay if the collision was with the player by checking the tag
        Debug.Log("Collided with player"); //place for behaviour such as +1 to the total score of caught objects
      }*/
      Destroy(gameObject); //destroy the object this script is attached to
    }
  }
}
