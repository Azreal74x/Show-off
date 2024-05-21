using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Showtext : MonoBehaviour
{
    public GameObject text;

    void Start()
    {
        text.SetActive(true);

        StartCoroutine(WaitForSec());

    }

    IEnumerator WaitForSec()
    {
        Debug.Log(" should start coroutine");
        yield return new WaitForSeconds(4);
         
        SceneManager.LoadScene("House1");
        Debug.Log(" should end coroutine");
    }

    void Update()
    {

    }



}
