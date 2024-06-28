using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour {
  public Transform target; // The target position to move to
  [SerializeField] private float duration = 1.0f; // Duration of the movement
  private bool isMoving = false; // Flag to prevent spamming

  void Start() {
    // Initialize if necessary
  }

  public void StartMovement() {
    if (isMoving) return; // Prevent multiple instances if already moving

    GameObject newFood = Instantiate(this.gameObject, transform);
    StartCoroutine(MoveToPosition(newFood, target.position, duration));
  }

  System.Collections.IEnumerator MoveToPosition(GameObject food, Vector3 target, float duration) {
    isMoving = true; // Set flag to true to indicate movement is in progress
    RectTransform rectTransform = food.GetComponent<RectTransform>();

    Vector3 startPosition = rectTransform.position;
    float elapsedTime = 0;

    while (elapsedTime < duration) {
      rectTransform.position = Vector3.Lerp(startPosition, target, elapsedTime / duration);
      elapsedTime += Time.deltaTime;
      yield return null;
    }

    rectTransform.position = target;
    Destroy(food);
    isMoving = false; // Reset flag after movement is complete
  }
}
