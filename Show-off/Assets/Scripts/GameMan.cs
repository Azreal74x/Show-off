using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{
    public static GameMan currentInstance;

    void Awake()
    {
        if (currentInstance != null)
        {
            Destroy(currentInstance);
            currentInstance = this;
        }
        else
        {
            currentInstance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BackButtonAction()
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Map"));
        SceneManager.LoadScene("Map", LoadSceneMode.Additive);
    }

    


}
