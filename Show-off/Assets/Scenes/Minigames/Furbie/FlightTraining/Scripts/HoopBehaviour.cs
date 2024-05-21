using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HoopBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 newPos;

    public static int score;

    public static int lives = 5;

    void Start()
    {
        newPos.z = speed;
        //Debug.Log(score);
    }

    void Update()
    {
        transform.position += newPos;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision with player");

            score++;
            Debug.Log(score);

        }
        else if (collision.gameObject.name == "Cube")
        {
            lives--;
            Debug.Log("missed one! lives = " + lives);
        }

        Debug.Log("collision with " + collision.gameObject.name);
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

        Destroy(gameObject);
    }
}
