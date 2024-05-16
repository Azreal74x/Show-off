using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BackButtonClick()
    {
        GameMan.currentInstance.BackButtonAction();
    }

}
