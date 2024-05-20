using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMonster : MonoBehaviour
{
    float firstTime;
    float lastTime;
    float difference;
    bool startedTimer = false;

    bool dragging = false;
    bool over = false;

    void Start()
    {
    }

    void Update()
    {
        Debug.Log("dragging? " + dragging);
        Debug.Log("over? " + over);

        if ((dragging && over) && !startedTimer) // if you are dragging, over and didn t start timing, starts the timer
        {
            firstTime = Time.time;
            startedTimer = true;
        }

        if ((!dragging || !over) && startedTimer) // if you stop dragging or ur not over the monster anymore then timer stops
        {
            lastTime = Time.time;
            difference = lastTime - firstTime;

            // calculates a score based on how much you pet the monster
            Debug.Log("nice petting! points gained: " + Mathf.CeilToInt( difference / 0.1f));

            startedTimer = false;
        }


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
