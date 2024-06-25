using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_Lives : MonoBehaviour
{
    [SerializeField] public int lives = 5;
    //[SerializeField] BoolSO F_IsHappy;

    [SerializeField] private List<GameObject> heartsObj;
    [SerializeField] private List<Sprite> heartsImg = new List<Sprite>();


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseLives()
    {
        if (lives > 0)
        {
            lives--;

            for (int i = heartsObj.Count - 1; i >= 0; i--)
            {
                if (heartsObj[i].GetComponent<Image>().sprite == heartsImg[0])
                {
                    heartsObj[i].GetComponent<Image>().sprite = heartsImg[1];
                    return;
                }

            }
        }

    }




}
