using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_MouseMovement : MonoBehaviour {
  
  [SerializeField] private Camera mainCamera; //main camera reference

  private void Start() {

  }

  private void Update() {
    Vector3 mousePosScreen = Input.mousePosition; //get mouse pos
    mousePosScreen.z = mainCamera.WorldToScreenPoint(transform.position).z; //get distance from camera to player
    Vector3 mousePosWorld = mainCamera.ScreenToWorldPoint(mousePosScreen); //convert screen position to world position, so mouse pos for player
    
    float leftBoundary = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mousePosScreen.z)).x; //get left boundary in world space
    float rightBoundary = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mousePosScreen.z)).x; //get right boundary in world space
    float clampX = Mathf.Clamp(mousePosWorld.x, leftBoundary, rightBoundary); //clamp player x pos to stay in boundaries
    
    transform.position = new Vector3(clampX, transform.position.y, transform.position.z); //set player position to current mouse pos but within the clamp
  }
}
