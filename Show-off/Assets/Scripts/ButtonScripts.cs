using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScripts : MonoBehaviour
{
    [SerializeField] private string F_gameName;
    [SerializeField] private string J_gameName;
    [SerializeField] private string T_gameName;
    
    [SerializeField] private string F_roomName;
    [SerializeField] private string J_roomName;
    [SerializeField] private string T_roomName;




    void Start()
    {
    }

    void Update()
    {
    }

    public void BackToHouses()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void Replay()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "F_GameOver" :
                SceneManager.LoadScene(F_gameName);
                break;

            case "J_GameOver":
                SceneManager.LoadScene(J_gameName);
                break;

            case "T_GameOver":
                SceneManager.LoadScene(T_gameName);
                break;

            default:
                Debug.Log("Invalid Reload");
                break;
        }

    }
    public void BackToRoom()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "F_GameOver":
                SceneManager.LoadScene(F_roomName);
                break;

            case "J_GameOver":
                SceneManager.LoadScene(J_roomName);
                break;

            case "T_GameOver":
                SceneManager.LoadScene(T_roomName);
                break;

            default:
                Debug.Log("Invalid Back");
                break;
        }

    }

   
    public void F_LoadHouse()
    {
        SceneManager.LoadScene("HouseFurbie"/*, LoadSceneMode.Additive*/);
    }
    public void T_LoadHouse()
    {
        SceneManager.LoadScene("HouseTamara"/*, LoadSceneMode.Additive*/);
    }
    public void J_LoadHouse()
    {
        SceneManager.LoadScene("HouseJemie"/*, LoadSceneMode.Additive*/);
    }

    public void LoadFurbieGame()
    {
        SceneManager.LoadScene("FlightTraining");
    }





}
