using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private ScoreSO scoreKeeper;

    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text highscore;

    [SerializeField] private string scoreText;
    [SerializeField] private string highscoreText;

    void Start()
    {
        score.text = scoreText + scoreKeeper.CurrentScoreValue.ToString();
        highscore.text = highscoreText + scoreKeeper.HighScoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
