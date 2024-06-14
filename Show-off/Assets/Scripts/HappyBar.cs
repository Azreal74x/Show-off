using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyBar : MonoBehaviour {

  public Slider slider;
  private float LastDecrease; //variable to keep track of time passed
  [SerializeField] private float decreaseDelay = 10f; //the delay between spawning of objects

  [SerializeField] private BoolSO J_IsHappy;
  [SerializeField] private BoolSO T_IsHappy;
  [SerializeField] private BoolSO F_IsHappy;

  [SerializeField] private GameObject faceImage;
  [SerializeField] private List<Sprite> blobs = new List<Sprite>();  

  void Start() {
    LastDecrease = Time.time; //set last spawn time to current time to keep track
  }

  void Update() {
    if (Time.time - LastDecrease >= decreaseDelay) {
      slider.value -= 1;
      LastDecrease = Time.time; //set last spawn time to current time to keep track from this point on again
    }

    ValueCheck();
  }

  public void AddHappyLevel(float happyLevel) {
    slider.value += happyLevel;
  }

  public void GoodFood() {
    slider.value += 20;
  }

  public void BadFood() {
    slider.value -= 20;
  }

  private void MinigameCheck() {
    if (J_IsHappy.Value == true) {
      slider.value += 20;
      J_IsHappy.Value = false;
    }

    if (T_IsHappy.Value == true) {
      slider.value += 20;
      T_IsHappy.Value = false;
    }

    if (F_IsHappy.Value == true) {
      slider.value += 20;
      F_IsHappy.Value = false;
    }
  }

  private void ValueCheck() {
    if(slider.value >= 70) {
      faceImage.GetComponent<Image>().sprite = blobs[0];
    }
    else if(slider.value <= 30) {
      faceImage.GetComponent<Image>().sprite = blobs[1];
    }
    else {
      faceImage.GetComponent<Image>().sprite = blobs[2];
    }
  }


}
