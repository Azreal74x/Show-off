using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class T_Score : MonoBehaviour {

  [SerializeField] TMP_Text scoreText;
  public float score;
  public bool canMove = true; //bool to keep track of pulling activity

  private void Start() {
    scoreText.text = score.ToString(); //set score text
  }

  private void Update() {

  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)
      if (collision.gameObject.tag == "Gold") { //startDelay if the collision was with a gold by checking the tag
        score += 1; //update score
        scoreText.text = score.ToString(); //update score text
        
        canMove = true;
      }
      else if (collision.gameObject.tag == "Stone") { //startDelay if the collision was with a stone by checking the tag
        canMove = true;
      }
    }
  }
}
