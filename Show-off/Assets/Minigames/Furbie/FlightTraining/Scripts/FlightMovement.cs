using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightMovement : MonoBehaviour
{

    public bool pressingThrottle = true;
    public bool throttle => pressingThrottle;

    public float pitchPower, rollPower, yawPower, enginePower;

    private float activeRoll, activePitch, activeYaw;

    Vector3 worldMousePos;


    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pressingThrottle == false)
            {

                pressingThrottle = true;

            }
            else if (pressingThrottle == true)
            {

                pressingThrottle = false;

            }
        }*/


        

        transform.position += transform.forward * enginePower * Time.deltaTime; // always moving forward


        Vector3 mousePos = Input.mousePosition; //store mouse pos
        mousePos.z = 10f; //set z offset
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos); //convert to world space pos


        Vector3 direction = worldMousePos - transform.position;
        Debug.Log(direction);

        /*activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
        activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.deltaTime;
        activeYaw = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;

        transform.Rotate(activePitch * pitchPower * Time.deltaTime,
            activeYaw * yawPower * Time.deltaTime,
            -activeRoll * rollPower * Time.deltaTime,
            Space.Self);*/

    }


}

