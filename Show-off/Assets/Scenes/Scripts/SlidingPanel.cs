using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class SlidingPanel : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform panel;

    public float canvasWidth;

    public void Start()
    {
        canvasWidth = canvas.gameObject.GetComponent<RectTransform>().rect.width;

        ClosePanel();


        // the problem here is sine u get the height only at the beginning and it s kinda expensive to have it saved in update it s not resizeable

    }


    public void Update()
    {
        //Debug.Log(width);
    }

    public void OpenPanel()
    {
        panel.anchoredPosition = new Vector2(0, 0);

    }
    public void ClosePanel()
    {
        panel.anchoredPosition = new Vector2(-canvasWidth / 3, 0);


    }

}
