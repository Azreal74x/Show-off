using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_FallenCandyCounter : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private J_Score score;

    [SerializeField] private List<GameObject> heartsObj;
    [SerializeField] private List<Sprite> heartsImg = new List<Sprite>();

    void Start()
    {
        score = player.GetComponent<J_Score>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GoodCandy" || other.tag == "BadCandy")
        {
            score.lostCandy += 1;

            for (int i = 0; i < heartsObj.Count; i++)
            {
                if (heartsObj[i].GetComponent<Image>().sprite == heartsImg[0])
                {
                    heartsObj[i].GetComponent<Image>().sprite = heartsImg[1];
                    Debug.Log("changed " + i + " from the back");
                    break;
                }

            }
        }
    }
}
