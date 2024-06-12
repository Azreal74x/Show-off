using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMonster : MonoBehaviour
{
    float firstTime;
    float lastTime;
    float difference;
    bool startedPet = false;

    bool dragging = false;
    bool over = false;

    [SerializeField] private HappyBar happinessBar;


    [SerializeField] private List<AudioClip> petSounds = new List<AudioClip>();
    private AudioSource audioSource;
    [SerializeField] private float soundDelay = 1f;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {


        if ((dragging && over) && !startedPet) // if you are dragging, over and didn t start timing, starts the timer
        {
            firstTime = Time.time;
            startedPet = true;
        }

        if ((!dragging || !over) && startedPet) // if you stop dragging or ur not over the monster anymore then timer stops
        {
            lastTime = Time.time;
            //difference = lastTime - firstTime;


            startedPet = false;
        }


        if (startedPet)
        {
            happinessBar.AddHappyLevel(0.1f);


            Debug.Log("diferenta" + (Time.time - firstTime));

            if (Time.time - firstTime >= soundDelay)
            {
                if (audioSource.isPlaying == false)
                {

                    audioSource.clip = petSounds[Random.Range(0, petSounds.Count)];
                    audioSource.Play();

                    firstTime = Time.time;

                }
            }
        }



        /*
         * 
        */

        /*
         *  DO NOT ASK WHY SO COMPLICATED 
         *  WHEN I DID IT LIKE BELOW IT CRASHED THE WHOLE ASS UNITY
        while (dragging && over)
        {
            happinessBar.AddHappyLevel(1);

        }*/


    }




    private void OnMouseDrag()
    {
        dragging = true;
    }
    private void OnMouseUp()
    {

        dragging = false;
    }

    private void OnMouseOver()
    {
        over = true;
    }


    private void OnMouseExit()
    {
        over = false;

    }

}
