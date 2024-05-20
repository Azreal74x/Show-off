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
        WaitForSec();

    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("House1");
    }

    void Update()
    {

    }



}
