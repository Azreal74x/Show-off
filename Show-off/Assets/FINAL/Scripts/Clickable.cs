using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Collider))]

public class Clickable : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }


    public void OnMouseEnter()
    {
        CursorControl.instance.Interactable();
    }
    public void OnMouseExit()
    {
        CursorControl.instance.Default();
    }

}
