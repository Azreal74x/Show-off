using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeyboard : MonoBehaviour {

  private bool moveLeft = false; //flag to keep track of keypresses
  private bool moveRight = false; //flag to keep track of keypresses

  [SerializeField] private float playerSpeed = 5f;

  void Start() {

  }

  void Update() {
    //keyboard movement controls
    if (Input.GetKey(KeyCode.A)) { //startDelay if A is pressed
      moveLeft = true; //set flag to true
    }
    else if (Input.GetKey(KeyCode.D)) { //startDelay if D is pressed
      moveRight = true; //set flag to true
    }
  }

  //keyboard movement controls
  private void FixedUpdate() {
    if (moveLeft) {
      transform.position -= new Vector3(1f * playerSpeed * Time.deltaTime, 0f, 0f); //make the player move left
      moveLeft = false; //set flag to false
    }
    else if (moveRight) {
      transform.position += new Vector3(1f * playerSpeed * Time.deltaTime, 0f, 0f); //make the player move right
      moveRight = false; //set flag to false
    }
  }
}
