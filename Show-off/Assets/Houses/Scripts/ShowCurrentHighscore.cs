using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCurrentHighscore : MonoBehaviour {
  [SerializeField] ScoreSO scoreKeeper;
  [SerializeField] TMP_Text highscoreText;

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    highscoreText.text = "Highscore: " + scoreKeeper.HighScoreValue.ToString();
  }
}
