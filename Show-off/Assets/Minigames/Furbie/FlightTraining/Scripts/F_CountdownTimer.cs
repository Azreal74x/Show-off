using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class F_CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float startingTime = 3f;

    [SerializeField] TMP_Text countdownText;

    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime >= 1)
        {
            countdownText.text = currentTime.ToString("0");
        }
        else if (currentTime <= 1 && currentTime >= 0)
        {
            countdownText.text = "GO!";
        }
        if (currentTime < 0)
        {

            Destroy(countdownText);
        }


    }
}
