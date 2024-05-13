using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  private bool moveLeft = false; //flag to keep track of keypresses
  private bool moveRight = false; //flag to keep track of keypresses

  [SerializeField] private float playerSpeed = 5f;

  private void Start() {

  }

  private void Update() { //check keypressed at all times so every frame
    if(Input.GetKey(KeyCode.A)) { //check if A is pressed
      moveLeft = true; //set flag to true
    }
    else if (Input.GetKey(KeyCode.D)) { //check if D is pressed
      moveRight = true; //set flag to true
    }
  }

  private void FixedUpdate() { //only move at fixedUpdate for physics
    if (moveLeft) { 
      transform.position -= new Vector3 (1f * playerSpeed * Time.deltaTime, 0f, 0f); //make the player move left
      moveLeft = false; //set flag to false
    }
    else if (moveRight) {
      transform.position += new Vector3(1f * playerSpeed * Time.deltaTime, 0f, 0f); //make the player move right
      moveRight = false; //set flag to false
    }
  }
}
