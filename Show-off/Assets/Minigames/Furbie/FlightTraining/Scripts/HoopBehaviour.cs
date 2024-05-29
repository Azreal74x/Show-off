using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class HoopBehaviour : MonoBehaviour
{
    private Vector3 newPos;

    public static float speed = 0.2f;

    public float shownr;

    public static int score;

    public static int lives = 5;

    [SerializeField] private bool hit = false;

    //  timer
    private float lastTime;

    static bool debugging = true;

    void Start()
    {


        lastTime = Time.time;
    }

    void Update()
    {

        if (Time.time - lastTime > 3f && speed < 1)
        {
            speed += 0.01f;
            lastTime = Time.time;
        }
        shownr = speed;

        newPos.z = speed;
        transform.position -= newPos;


        CheckLives();

    }
    private void CheckLives()
    {
        if (lives == 0)
        {
            lives = -1;

            Debug.Log("GAMEOVER");
            ObjectSpawner spawner = GetComponentInParent<ObjectSpawner>();

            spawner.GetComponent<Showtext>().enabled = true;

            for (var i = spawner.transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(spawner.transform.GetChild(i).gameObject);
            }
            spawner.enabled = false;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Cube")
        {

            if (hit == false && debugging == false)
            {
                Debug.Log("missed one! lives = " + lives);
                lives--;
            }


            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("collision with player");

            hit = true;
            score++;
            Debug.Log("you got it! score: " + score);

        }
        
    }




}
