using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BulletSpawner : MonoBehaviour {

  private GameObject instantiatePrefab = null; //the object that will be created
  [SerializeField] private GameObject bullet; //reference to bullet prefab
  [SerializeField] private GameObject bulletSpawner; //reference to bullet prefab
  [SerializeField] private Transform bulletParent; //empty parent obj to spawn bullets in

  [SerializeField] private int amplitude = 80;
  [SerializeField] private float beamSpeed = 1f;

  private float aimTimer;

  [SerializeField] GameObject player; //reference to Player obj
  T_Score scoreBehaviour; //reference to ScoreBehaviour script

  [SerializeField] SoundManager soundManager;

  private void Start() {
    aimTimer = 0f;

    scoreBehaviour = player.GetComponent<T_Score>();
  }

  private void Update() {
    if (Input.GetMouseButtonDown(0) && scoreBehaviour.canMove) { //if left mouse click
      instantiatePrefab = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation, bulletParent); //spawn bullet in the bulletParent obj    
      scoreBehaviour.canMove = false;
      soundManager.PlayT_BeamSound();
    }
  }


  private void FixedUpdate() {
    if (scoreBehaviour.canMove) {
      aimTimer += Time.fixedDeltaTime * beamSpeed; //increase aimTimer only when canMove is true and multiply with beamSpeed
      transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(aimTimer) * amplitude); //make beam move left to right
    }
  }

}
