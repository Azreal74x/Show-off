using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    Vector3 newPos;

    public float offset;

    void Start()
    {
    }

    void Update()
    {
        newPos = Input.mousePosition;
        newPos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(newPos);
        //Debug.Log("mouse x pos = " + newPos.x);
        //Debug.Log("mouse y pos = " + newPos.y);


    }
}
