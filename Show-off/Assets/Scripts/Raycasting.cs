using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Raycasting : MonoBehaviour
{
    public float rayLenght;
    public LayerMask layerMask;

    public string house1name;
    public string house2name;
    public string house3name;


    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())   //if mouse is clicked and mouse is not over any ui elements
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLenght, layerMask))
            {
                Debug.Log("clicked " + hit.collider.gameObject.name);
                /*switch (hit.collider.name)
                {
                    case house1name:
                        GameMan.currentInstance.LoadHouse1();
                        break;
                    case house2name:
                        GameMan.currentInstance.LoadHouse2();
                        break;
                    case house3name:
                        GameMan.currentInstance.LoadHouse3();
                        break;
                    default:
                        Debug.Log("no coresponding house");
                        break;
                }*/

                if (hit.collider.gameObject.name == house1name)
                {
                    GameMan.currentInstance.LoadHouse1();
                }
                else if (hit.collider.gameObject.name == house2name)
                {
                    GameMan.currentInstance.LoadHouse2();
                }
                else if (hit.collider.gameObject.name == house3name)
                {
                    GameMan.currentInstance.LoadHouse3();
                }
            }
        }
    }
}
