using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F_MouseMovement : MonoBehaviour
{


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
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;

            this.gameObject.GetComponent<F_MouseMovement>().enabled = false;

            StartCoroutine( WaitForSec() );
        }


    }

    IEnumerator WaitForSec()
    {
        Debug.Log(" should start coroutine");
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("F_GameOver");
        Debug.Log(" should end coroutine");
    }

}








