using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_MouseMovement : MonoBehaviour {
  public ButtonScripts sceneSwitchScripts;

  Vector3 worldMousePos;
  public float offset;
  public float speed = 2f; // easing speed
  private bool canmove = true;

  [SerializeField] TMP_Text scoreText;
  public float score = 0;

  [SerializeField] private ScoreSO scoreKeeperSO;

  [SerializeField] private GameObject wall;
  private int lives;

  [SerializeField] private BoolSO F_IsHappy;

  [SerializeField] private SoundManager soundManager;

  void Start() {
    //lives = wall.GetComponent<F_Lives>().lives;
  }

  void Update() {
    if (canmove) {

      Vector3 mousePos = Input.mousePosition; //store mouse pos
      mousePos.z = offset; //set z offset
      worldMousePos = Camera.main.ScreenToWorldPoint(mousePos); //convert to world space pos

      // gets the direction where the player is heading
      Vector3 direction = worldMousePos - transform.position;

      transform.position = Vector3.Lerp(transform.position, worldMousePos, speed * Time.deltaTime); //lerp to ease player to mouse pos


      // clamps the up/down values so it points forward
      direction.y = Mathf.Clamp(direction.y, -1, 1);
      direction.z = Mathf.Clamp(direction.z, 0.5f, 1);

      // in targetRotation is a quat with the rotation of direction as forward
      Quaternion targetRotation = Quaternion.LookRotation(direction);

      // clamp again rotation so it doesn t rotate too much
      targetRotation.x = Mathf.Clamp(targetRotation.x, -0.1f, 0.1f);
      targetRotation.y = Mathf.Clamp(targetRotation.y, -0.2f, 0.2f);

      // kinda slowly rotate player so it points to where it s going
      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

    }



    CheckLives();

  }

  void CheckLives() {
    //  CHANGE THISSSS
    lives = wall.GetComponent<F_Lives>().lives;

    if (lives <= 0) {
      lives = -1;

      StartCoroutine(WaitForSec());

      //F_IsHappy.Value = true;
    }
  }


  private void OnCollisionEnter(Collision other) // hit the sides then game ends
  {
    if (other.gameObject.tag == "Hoop") {
      // player falls dramatically, code waits for it, then gameover scene

      StartCoroutine(WaitForSec());

    }


  }

  private void OnTriggerEnter(Collider other) // went through the center so score++
  {
    if (other.gameObject.tag == "Hoop") {
      //update score & text
      score += 1;
      scoreText.text = score.ToString();
      soundManager.PlayF_FlyThroughHoopSound();

    }

  }
  IEnumerator WaitForSec() {
    soundManager.PlayF_HittingHoopSound();
    this.gameObject.GetComponent<Rigidbody>().useGravity = true;
    canmove = false;

    yield return new WaitForSeconds(2);

    FurbieDied();
  }


  public void FurbieDied() {
    // save current score
    scoreKeeperSO.CurrentScoreValue = score;

    // update highscoreSound
    if (score > scoreKeeperSO.HighScoreValue) {
      scoreKeeperSO.HighScoreValue = score;
    }

    sceneSwitchScripts.GameOver();

    F_IsHappy.Value = true;

  }



}








