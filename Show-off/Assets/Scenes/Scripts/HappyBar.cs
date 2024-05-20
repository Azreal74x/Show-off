using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyBar : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
    }

    void Update()
    {
    }

    public void AddHappyLevel(float happyLevel)
    {
        slider.value += happyLevel;

    }

    public void GoodFood()
    {
        slider.value += 20;
    }

    public void BadFood()
    {
        slider.value -= 20;
    }

}
