using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPanel : MonoBehaviour
{
    [SerializeField] private string panelSide;

    public Canvas canvas;
    public RectTransform panel;

    public float canvasWidth;

    float resultWidth;
    float actualWidth;

    int panelMovement;

    private bool open = false;

    // state identifier for which ovement is the panel doing
    // 0 = nothing
    // 1 = opening
    // 2 = closing

    public void Start()
    {
        canvasWidth = canvas.gameObject.GetComponent<RectTransform>().rect.width;

        // the problem here is sine u get the height only at the beginning and it s kinda expensive to have it saved in update it s not resizeable

    }


    public void Update()
    {

        if (panelMovement != 0)
        {
            if (panelMovement == 1)
            {
                if (panelSide == "left")
                {
                    actualWidth += 700 * Time.deltaTime; // canvaswidth instead of 700
                    if (actualWidth >= resultWidth)
                    {
                        actualWidth = 0;
                        panelMovement = 0;
                    }
                }
                else
                {
                    //for right side is the smae but with -
                    actualWidth -= 700 * Time.deltaTime;
                    if (actualWidth <= resultWidth)
                    {
                        actualWidth = resultWidth;
                        panelMovement = 0;
                    }
                }
            }
            else
            if (panelMovement == 2)
            {
                if (panelSide == "left")
                {
                    actualWidth -= 700 * Time.deltaTime;
                    if (actualWidth <= resultWidth)
                    {
                        actualWidth = resultWidth;
                        panelMovement = 0;
                    }
                }
                else
                {
                    actualWidth += 700 * Time.deltaTime;
                    if (actualWidth >= resultWidth)
                    {
                        actualWidth = resultWidth;
                        panelMovement = 0;
                    }

                }
            }
            panel.anchoredPosition = new Vector2(actualWidth, 0);


        }

    }

    public void OpenPanel()
    {
        if (open == false)
        {
            open = true;

            if (panelSide == "left")
            {
                resultWidth = 0;
                actualWidth = -canvasWidth / 3;
            }
            else
            {

                resultWidth = 0;
                actualWidth = canvasWidth / 3;
            }

            panelMovement = 1;

            //panel.anchoredPosition = new Vector2(0, 0);

        }
    }

    public void ClosePanel()
    {
        open = false;

        if (panelSide == "left")
        {
            resultWidth = -canvasWidth / 3 - 100;
            actualWidth = 0;
        }
        else
        {
            resultWidth = canvasWidth / 3 +100;
            actualWidth = 0;
        }
        panelMovement = 2;
        //panel.anchoredPosition = new Vector2(-canvasWidth / 3, 0);

    }

}
