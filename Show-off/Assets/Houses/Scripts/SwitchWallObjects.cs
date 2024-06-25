using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWallObjects : Clickable
{
    [SerializeField] private List<GameObject> wallObjects = new List<GameObject>(); // list of objects
    private int activeObjIndex = -1;

    [SerializeField] private SoundManager soundManager;

    void Start()
    {
        if (activeObjIndex == -1) // do this only the first time
        {
            for (int i = 0; i < wallObjects.Count; i++) //turn off all objects
            {
                wallObjects[i].SetActive(false);
            }

            wallObjects[0].SetActive(true); // turn on only first one
            activeObjIndex = 0;

        }
    }

    void Update()
    {
    }

    private void OnMouseUp()
    {
        // disable the current
        wallObjects[activeObjIndex].SetActive(false);

        // +1 the index and make sure it cycles
        activeObjIndex = (activeObjIndex + 1) % wallObjects.Count;

        wallObjects[activeObjIndex].SetActive(true);

        soundManager.PlayChangeObjectSound();
    }

}
