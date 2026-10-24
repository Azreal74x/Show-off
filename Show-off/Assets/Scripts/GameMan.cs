using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour {
  public static GameMan currentInstance;


  void Awake() {
    if (currentInstance != null) {
      Destroy(currentInstance);
      currentInstance = this;
    }
    else {
      currentInstance = this;
    }
  }

  void Start() {

  }

  void Update() {

  }

  /*public void BackButtonAction()
  {
      //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Map"));
      SceneManager.LoadScene("HomeScene"*//*, LoadSceneMode.Additive*//*);
  }
  public void LoadHouse1()
  {
      SceneManager.LoadScene("HouseFurbie"*//*, LoadSceneMode.Additive*//*);
  }
  public void LoadHouse2()
  {
      SceneManager.LoadScene("HouseTamara"*//*, LoadSceneMode.Additive*//*);
  }
  public void LoadHouse3()
  {
      SceneManager.LoadScene("HouseJemie"*//*, LoadSceneMode.Additive*//*);
  }

  public void LoadFurbieGame()
  {
      SceneManager.LoadScene("FlightTraining");
  }*/




}
