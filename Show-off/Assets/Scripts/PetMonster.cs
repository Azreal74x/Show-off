using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMonster : MonoBehaviour {
  float firstTime;
  float lastTime;
  float difference;
  bool startedPet = false;

  bool dragging = false;
  bool over = false;

  [SerializeField] private HappyBar happinessBar;


  [SerializeField] private SoundManager soundManager;
  private bool playSound = false;

  [SerializeField] GameObject particles;
  private ParticleSystem partSyst;

  [SerializeField] private GameObject catBoard;

  void Start() {
    partSyst = particles.GetComponent<ParticleSystem>();
  }

  void Update() {
    if (!catBoard.activeSelf) {

      if ((dragging && over) && !startedPet) // if you are dragging, over and didn t start timing, starts the timer
      {
        firstTime = Time.time;
        startedPet = true;
        partSyst.Play();

      }

      if ((!dragging || !over) && startedPet) // if you stop dragging or ur not over the monster anymore then timer stops
      {
        lastTime = Time.time;
        startedPet = false;
        playSound = false;
      }


      if (startedPet) {
        happinessBar.AddHappyLevel(0.1f);


        if (!playSound) {
          playSound = true;
          if (gameObject.tag == "Furbie") {
            soundManager.PlayF_PettingSound();
          }
          else if (gameObject.tag == "Jemie") {
            soundManager.PlayJ_PettingSound();
          }
          else if (gameObject.tag == "Tamara") {
            soundManager.PlayT_PettingSound();
          }
        }

      }




      /*
       * 
      */

      /*
       *  DO NOT ASK WHY SO COMPLICATED 
       *  WHEN I DID IT LIKE BELOW IT CRASHED THE WHOLE ASS UNITY
      while (dragging && over)
      {
          happinessBar.AddHappyLevel(1);

      }*/

    }
  }




  private void OnMouseDrag() {
    dragging = true;
  }
  private void OnMouseUp() {

    dragging = false;
    partSyst.Stop();

  }

  private void OnMouseOver() {
    over = true;
  }

  private void OnMouseExit() {
    over = false;
    partSyst.Stop();

  }

}
