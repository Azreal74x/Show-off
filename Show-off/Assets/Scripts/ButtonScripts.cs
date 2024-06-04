using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScripts : MonoBehaviour {
  [SerializeField] private string houseScene;

  [SerializeField] private string F_gameName;
  [SerializeField] private string J_gameName;
  [SerializeField] private string T_gameName;

  [SerializeField] private string F_roomName;
  [SerializeField] private string J_roomName;
  [SerializeField] private string T_roomName;

  [SerializeField] private string F_gameover;
  [SerializeField] private string J_gameover;
  [SerializeField] private string T_gameover;



  [SerializeField] private AudioClip buttonClickSound;
  private AudioSource audioSource;

  void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  void Update() {

  }

  public void LoadMainHouseScene() {
    SceneManager.LoadScene(houseScene);
  }

  //specifc methods for each game
  public void F_LoadGame() {
    SceneManager.LoadScene(F_gameName);
  }
  public void T_LoadGame() {
    SceneManager.LoadScene(T_gameName);
  }
  public void J_LoadGame() {
    SceneManager.LoadScene(J_gameName);
  }

  //specific method for each house click
  public void F_LoadHouse() {
    SceneManager.LoadScene("F_House");
  }
  public void T_LoadHouse() {
    SceneManager.LoadScene("T_House");
  }
  public void J_LoadHouse() {
    SceneManager.LoadScene("J_House");
  }

  //depending in what scene u are, it goes to the coresponding next scene
  public void Replay() {
    if (SceneManager.GetActiveScene().name == F_gameover) {
      SceneManager.LoadScene(F_gameName);
    }
    else

    if (SceneManager.GetActiveScene().name == J_gameover) {
      SceneManager.LoadScene(J_gameName);
    }
    else

    if (SceneManager.GetActiveScene().name == T_gameover) {
      SceneManager.LoadScene(T_gameName);
    }

  }


  public void BackToRoom() {
    if (SceneManager.GetActiveScene().name == F_gameover) {
      SceneManager.LoadScene(F_roomName);
    }
    else

    if (SceneManager.GetActiveScene().name == J_gameover) {
      SceneManager.LoadScene(J_roomName);
    }
    else

    if (SceneManager.GetActiveScene().name == T_gameover) {
      SceneManager.LoadScene(T_roomName);
    }

  }



  public void GameOver() {
    if (SceneManager.GetActiveScene().name == F_gameName) {
      SceneManager.LoadScene(F_gameover);
    }
    else

    if (SceneManager.GetActiveScene().name == J_gameName) {
      SceneManager.LoadScene(J_gameover);
    }
    else

    if (SceneManager.GetActiveScene().name == T_gameName) {
      SceneManager.LoadScene(T_gameover);
    }

  }

  public void PlayButtonSound() {
    audioSource.clip = buttonClickSound;
    audioSource.Play();
  }



}
