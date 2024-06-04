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

  void Start() {
  }

  void Update() {
    //Debug.Log("dragging? " + dragging);
    //Debug.Log("over? " + over);

    if ((dragging && over) && !startedPet) // if you are dragging, over and didn t start timing, starts the timer
    {
      firstTime = Time.time;
      startedPet = true;
    }

    if ((!dragging || !over) && startedPet) // if you stop dragging or ur not over the monster anymore then timer stops
    {
      lastTime = Time.time;
      difference = lastTime - firstTime;

      // calculates a score based on how much you pet the monster
      //Debug.Log("nice petting! points gained: " + Mathf.CeilToInt( difference / 0.1f));
      //happinessBar.AddHappyLevel(difference * 100);

      startedPet = false;
    }

    if (startedPet) {
      happinessBar.AddHappyLevel(0.1f);
    }

    if (Input.GetMouseButtonDown(0)) {
      if (startedPet) {
        //playsound
        Debug.Log("PETTING");
      }
    }

    /*
     *  DO NOT ASK WHY SO COMPLICATED 
     *  WHEN I DID IT LIKE BELOW IT CRASHED THE WHOLE ASS UNITY
    while (dragging && over)
    {
        happinessBar.AddHappyLevel(1);

    }*/


  }

  private void OnMouseDrag() {
    dragging = true;
  }
  private void OnMouseUp() {

    dragging = false;
  }

  private void OnMouseOver() {
    over = true;
  }


  private void OnMouseExit() {
    over = false;

  }

}
