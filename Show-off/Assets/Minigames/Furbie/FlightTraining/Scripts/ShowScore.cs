using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {
  [SerializeField] private ScoreSO scoreKeeper;

  [SerializeField] private TMP_Text score;
  [SerializeField] private TMP_Text highscore;

  [SerializeField] private string scoreText;
  [SerializeField] private string highscoreText;

  [SerializeField] private List<GameObject> images = new List<GameObject>();

  [SerializeField] private SoundManager soundManager;
  private bool isPlayed = false;

  // images[0] = gameover  /  images[1] = highscoreSound

  void Start() {
    score.text = scoreText + scoreKeeper.CurrentScoreValue.ToString();
    highscore.text = highscoreText + scoreKeeper.HighScoreValue.ToString();

    if (scoreKeeper.HighScoreValue != 0 && scoreKeeper.CurrentScoreValue == scoreKeeper.HighScoreValue) {
      images[0].SetActive(false);
      images[1].SetActive(true);
    }
  }

  // Update is called once per frame
  void Update() {
    PlaySound();
  }

  private void PlaySound() {
    if (!isPlayed) {
      if (scoreKeeper.HighScoreValue != 0 && scoreKeeper.CurrentScoreValue == scoreKeeper.HighScoreValue) {
        soundManager.PlayHighscoreSound();
        isPlayed = true;
      }
      else {
        soundManager.PlayTryAgainSound();
        isPlayed = true;
      }
    }
  }
}
