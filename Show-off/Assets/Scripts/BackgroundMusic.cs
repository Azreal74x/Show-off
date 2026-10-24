using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour {
  public static BackgroundMusic instance;

  private void Awake() {
    if (instance != null)
      Destroy(gameObject);
    else {
      instance = this;
      DontDestroyOnLoad(this.gameObject);
    }
  }

  private void Update() {
    if (SceneManager.GetActiveScene().name == "FlightTraining" || SceneManager.GetActiveScene().name == "CandyCatch" || SceneManager.GetActiveScene().name == "MagicPractice") {
      BackgroundMusic.instance.GetComponent<AudioSource>().Pause();
    }
    else {
      if (!BackgroundMusic.instance.GetComponent<AudioSource>().isPlaying)
        BackgroundMusic.instance.GetComponent<AudioSource>().Play();
    }
  }
}


