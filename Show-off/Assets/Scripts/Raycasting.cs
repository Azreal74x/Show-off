using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Raycasting : MonoBehaviour
{
    public float rayLenght;
    public LayerMask layerMask;

    public string F_house;
    public string T_house;
    public string J_house;

    public ButtonScripts buttons;


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
                

                if (hit.collider.gameObject.name == F_house)
                {
                    buttons.F_LoadHouse();
                }
                else if (hit.collider.gameObject.name == T_house)
                {
                    buttons.T_LoadHouse();
                }
                else if (hit.collider.gameObject.name == J_house)
                {
                    buttons.J_LoadHouse();
                }
            }
        }
    }
}
