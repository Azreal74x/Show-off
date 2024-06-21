using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class T_Timer : MonoBehaviour
{

    [SerializeField] public float countdown = 20f;

    [SerializeField] TMP_Text timeText;
    [SerializeField] private BoolSO T_isHappy;

    //[SerializeField] private GameObject houseTamaraButton;

    [SerializeField] private ScoreSO scoreKeeperSO;
    private T_Score T_Score;

    [SerializeField] ButtonScripts buttonScripts;


    private void Start()
    {
        T_Score = gameObject.GetComponent<T_Score>();
    }

    private void Update()
    {
        timeText.text = Mathf.FloorToInt(countdown).ToString();

        if (countdown > 1)
        {
            countdown -= Time.deltaTime;
        }
        else if (countdown <= 1)
        { //if game end / timer end
            countdown = 0;
            T_isHappy.Value = true;
            //houseTamaraButton.SetActive(true);

            if (T_Score.score > scoreKeeperSO.HighScoreValue)
            { //if current score is higher than high score
                scoreKeeperSO.HighScoreValue = T_Score.score; //set high score to current score
            }

            scoreKeeperSO.CurrentScoreValue = T_Score.score; //save current score

            buttonScripts.GameOver();
        }
    }



}
