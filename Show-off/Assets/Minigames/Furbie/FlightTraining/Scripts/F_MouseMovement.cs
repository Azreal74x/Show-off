using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class F_MouseMovement : MonoBehaviour
{
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


    void Start()
    {
        lives = wall.GetComponent<F_Lives>().lives;
    }

    void Update()
    {
        if (canmove)
        {

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

    }


    private void OnCollisionEnter(Collision other) // hit the sides so game ends
    {
        if (other.gameObject.tag == "Hoop")
        {
            // player falls dramatically, code waits for it, then gameover scene
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            canmove = false;
            StartCoroutine(WaitForSec());

        }


    }

    private void OnTriggerEnter(Collider other) // went through the center so score++
    {
        if (other.gameObject.tag == "Hoop")
        {
            //update score & text
            score += 1;
            scoreText.text = score.ToString();
            

        }

    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);

        FurbieDied();
    }

    public void FurbieDied()
    {
        Debug.Log("dead");
        // save current score
        scoreKeeperSO.CurrentScoreValue = score;

        // update highscore
        if (score > scoreKeeperSO.HighScoreValue)
        { 
            scoreKeeperSO.HighScoreValue = score; 
        }

        sceneSwitchScripts.GameOver();
    }



}








