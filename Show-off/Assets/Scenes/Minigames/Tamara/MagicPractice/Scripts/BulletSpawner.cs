using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

  private GameObject instantiatePrefab = null; //the object that will be created
  [SerializeField] private GameObject bullet; //reference to bullet prefab
  [SerializeField] private GameObject bulletSpawner; //reference to bullet prefab
  [SerializeField] private Transform bulletParent; //empty parent obj to spawn bullets in

  [SerializeField] private int amplitude = 80;

  private float lastSpawnTime; //variable to keep track of time passed
  private float aimTimer;

 [SerializeField] private float cooldown = 5f; //cooldown until you can shoot again
  public bool canMove = true;


  private void Start() {
    lastSpawnTime = Time.time; //set last spawn time to current time to keep track
    aimTimer = 0f;
  }

  private void Update() {
    if (Time.time - lastSpawnTime >= cooldown) { //if time - last spawn time is bigger than time passed, so if this amount of time passed
      if (Input.GetMouseButtonDown(0)) { //if left mouse click
        instantiatePrefab = Instantiate(bullet, bulletSpawner.transform.position, transform.rotation, bulletParent); //spawn bullet in the bulletParent obj    
        canMove = false;
        lastSpawnTime = Time.time; // set last spawn time to current time to keep track from this point on again
      }
      else {
        canMove = true;
      }
    }
  }


  private void FixedUpdate() {
    if (canMove) {
      aimTimer += Time.fixedDeltaTime; //increase only when canMove is true
      transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(aimTimer) * amplitude); //make beam move left to right
    }
  }

}
