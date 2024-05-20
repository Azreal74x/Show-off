using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
  /*Vector3 newPos;

  public float offset;

  void Start()
  {
  }

  void Update()
  {
      newPos = Input.mousePosition;
      newPos.z = offset;
      transform.position = Camera.main.ScreenToWorldPoint(newPos);
      //Debug.Log("mouse x pos = " + newPos.x);
      //Debug.Log("mouse y pos = " + newPos.y);


  }
  */

  Vector3 targetPos;
  public float offset; 
  public float speed = 2f; // easing speed

  void Start() {
  }

  void Update() {
    Vector3 mousePos = Input.mousePosition; //store mouse pos
    mousePos.z = offset; //set z offset
    targetPos = Camera.main.ScreenToWorldPoint(mousePos); //convert to world space pos

    transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime); //lerp to ease player to mouse pos

  }

}

