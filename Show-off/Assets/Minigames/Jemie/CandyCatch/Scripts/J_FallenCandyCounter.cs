using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_FallenCandyCounter : MonoBehaviour {

  [SerializeField] private GameObject player;
  private J_Score score;

  void Start() {
    score = player.GetComponent<J_Score>();
  }

  void Update() {
   
  }

  private void OnTriggerEnter(Collider other) {
    if (other.tag == "GoodCandy" || other.tag == "BadCandy") {
      score.lostCandy += 1;
    }
  }
}
