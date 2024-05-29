using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

   // [SerializeField] private Rigidbody rb;
    /*Vector3 newPos;

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
    */

    Vector3 worldMousePos;
    public float offset;
    public float speed = 2f; // easing speed

    void Start()
    {
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition; //store mouse pos
        mousePos.z = offset; //set z offset
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos); //convert to world space pos

        Vector3 direction = worldMousePos - transform.position;

        transform.position = Vector3.Lerp(transform.position, worldMousePos, speed * Time.deltaTime); //lerp to ease player to mouse pos

        //Debug.Log("direction = "+ direction);


        direction.y = Mathf.Clamp(direction.y, -1, 1);
        direction.z = Mathf.Clamp(direction.z, 0.5f, 1);

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        targetRotation.x = Mathf.Clamp(targetRotation.x, -0.1f, 0.1f);
        targetRotation.y = Mathf.Clamp(targetRotation.y, -0.2f, 0.2f);

        //Debug.Log("targetRotation = " + targetRotation);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        //transform.rotation = targetRotation;


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hoop")
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity= true;

            this.gameObject.GetComponent<MouseMovement>().enabled = false;
            
        }

        
    }



}

