using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour
{
    //public GameObject ballPrefab; // The ball prefab to spawn
    public Transform target; // The target position to move to
    [SerializeField] private float duration = 1.0f; // Duration of the movement
    //public Button spawnButton; // Button to spawn the balls

    void Start()
    {
        
    }

    public void StartMovement()
    {
        GameObject newFood = Instantiate(this.gameObject, transform);
        StartCoroutine(MoveToPosition(newFood, target.position, duration));
    }

    System.Collections.IEnumerator MoveToPosition(GameObject food, Vector3 target, float duration)
    {
        RectTransform rectTransform = food.GetComponent<RectTransform>();
        //rectTransform.localScale = this.transform.localScale;
        
        Vector3 startPosition = rectTransform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            rectTransform.position = Vector3.Lerp(startPosition, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.position = target;
        Destroy(food);
    }
}
