using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class J_Score : MonoBehaviour {

  [SerializeField] TMP_Text scoreText;
  [SerializeField] private FloatSO highScoreSO;
  private float score;
  public float lostCandy = 0;

  [SerializeField] private BoolSO J_IsHappy;
  [SerializeField] private GameObject houseJemieButton;

  private void Start() {
    scoreText.text = score.ToString(); //set score text
  }

  private void Update() {
    if(lostCandy >= 5) {
      J_IsHappy.Value = true;
      houseJemieButton.SetActive(true);
    }
  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)
      if (collision.gameObject.tag == "GoodCandy") { //startDelay if the collision was with a good candy by checking the tag
        score += 1; //update score
        scoreText.text = score.ToString(); //update score text

        if (score > highScoreSO.Value) { //if current score is higher than high score
          highScoreSO.Value = score; //set high score to current score
        }
      }
      if (collision.gameObject.tag == "BadCandy") {
        lostCandy += 1;
      }
    }
  }
}
