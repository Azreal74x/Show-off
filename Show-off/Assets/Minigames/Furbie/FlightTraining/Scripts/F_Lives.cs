using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Lives : MonoBehaviour
{
    [SerializeField] public int lives = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            lives = -1;

            Debug.Log("GAMEOVER");




        }
    }



}
