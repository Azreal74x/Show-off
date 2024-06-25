using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class F_HoopBehaviour : MonoBehaviour
{
    private Vector3 newPos;

    public float speed;

    public float shownr;

    public static int score;

    //public static int lives = 5;

    [SerializeField] private bool hit = false;

    //  timer
    private float lastTime;

    static bool debugging = false;

    [SerializeField]  private bool decreasedLife = false;

    //  particles
    [SerializeField] GameObject particles;
    private ParticleSystem partSyst;

    void Start()
    {
        partSyst = particles.GetComponent<ParticleSystem>();

        lastTime = Time.time;
    }

    void Update()
    {
        newPos.z = speed;
        transform.position -= newPos;

        //CheckLives();
    }

   

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Cube")
        {

            if (hit == false && debugging == false && decreasedLife == false)
            {
                other.gameObject.GetComponent<F_Lives>().DecreaseLives();
                decreasedLife = true;
                //other.gameObject.GetComponent<F_Lives>().lives--;
            }


      Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hit = true;
            partSyst.Play();


        }

    }




}
