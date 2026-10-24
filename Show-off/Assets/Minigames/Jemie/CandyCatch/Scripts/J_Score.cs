using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class J_Score : MonoBehaviour {

  [SerializeField] TMP_Text scoreText;
  [SerializeField] private ScoreSO scoreKeeperSO;
  private float score;
  public float lostCandy = 0;

  [SerializeField] private BoolSO J_IsHappy;
  [SerializeField] private GameObject houseJemieButton;

  [SerializeField] ButtonScripts buttonScripts;
  [SerializeField] SoundManager soundManager;


  [SerializeField] public List<GameObject> heartsObj;
  [SerializeField] private List<Sprite> heartsImg = new List<Sprite>();

  private void Start() {
    scoreText.text = score.ToString(); //set score text
  }

  private void Update() {
    if (lostCandy >= 5) { //game end
      J_IsHappy.Value = true;
      //houseJemieButton.SetActive(true);

      if (score > scoreKeeperSO.HighScoreValue) { //if current score is higher than high score
        scoreKeeperSO.HighScoreValue = score; //set high score to current score
      }

      scoreKeeperSO.CurrentScoreValue = score;

      buttonScripts.GameOver();
    }

  }

  private void OnCollisionEnter(Collision collision) { //method for collision checking
    if (collision != null) { //if we collided with anything (we = the object this script is attached to)
      if (collision.gameObject.tag == "GoodCandy") { //startDelay if the collision was with a good candy by checking the tag
        score += 1; //update score
        scoreText.text = score.ToString(); //update score text
        soundManager.PlayJ_GoodCandyCatchSound();
      }
      if (collision.gameObject.tag == "BadCandy") {
        soundManager.PlayJ_BadCandyCatchSound(); //should be bad candy

        lostCandy += 1;

        RemoveHeart();

      }
    }
  }


  public void RemoveHeart() {
    for (int i = 0; i < heartsObj.Count; i++) {
      if (heartsObj[i].GetComponent<Image>().sprite == heartsImg[0]) {
        heartsObj[i].GetComponent<Image>().sprite = heartsImg[1];

        break;
      }

    }
  }
}
