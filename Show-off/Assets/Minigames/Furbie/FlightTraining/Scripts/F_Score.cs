using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class F_Score : MonoBehaviour {

  [SerializeField] TMP_Text scoreText;
  public float score = 0;
  [SerializeField] private FloatSO highScoreSO;

  [SerializeField] SoundManager soundManager;

  private void Start() {
    scoreText.text = score.ToString(); //set score text
  }

  private void Update() {

  }

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Hoop") {
      //update score & text
      score += 1;
      scoreText.text = score.ToString();
      //soundManager.PlayF_WooshSound(); 

      if (score > highScoreSO.Value) {
        //set high score to current score
        highScoreSO.Value = score;
      }

    }

  }

}