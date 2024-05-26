using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

  [SerializeField] private float countdown = 60f;

  [SerializeField] TMP_Text timeText;

  private void Start() {

  }

  private void Update() {
    timeText.text = Mathf.FloorToInt(countdown).ToString();

    if(countdown > 0){
      countdown -= Time.deltaTime;
    }
    else if(countdown == 0){
      //SceneManager.LoadScene("HouseTamara"); //name has to be set to actual HouseTamara name
    }
  }

    

}
