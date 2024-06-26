using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_TrailBehaviour : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
  }

  // Update is called once per frame
  void Update() {

  }

  void OnCollisionEnter(Collision other) {
    if (other != null) {
      transform.position = new Vector3(180f, transform.position.y, transform.position.z);
    }
  }
}
