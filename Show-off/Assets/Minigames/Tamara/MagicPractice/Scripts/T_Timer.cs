using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T_Timer : MonoBehaviour {

  [SerializeField] private float countdown = 60f;

  [SerializeField] TMP_Text timeText;
  [SerializeField] private BoolSO T_isHappy;

  [SerializeField] private GameObject houseTamaraButton;

  private void Start() {

  }

  private void Update() {
    timeText.text = Mathf.FloorToInt(countdown).ToString();

    if(countdown > 0){
      countdown -= Time.deltaTime;
    }
    else if(countdown <= 0){
      countdown = 0;
      T_isHappy.Value = true;
      houseTamaraButton.SetActive(true);
    }
  }

    

}
