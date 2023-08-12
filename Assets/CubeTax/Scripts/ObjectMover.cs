using System.Collections;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Transform target; // The target position the object will move towards
    public float moveSpeed = 5f; // The speed at which the object will move
    public float arrivalThreshold = 0.1f; // The distance at which the object is considered to have arrived

    private bool isMoving = false;

    public void StartMoving()
    {
        if (target != null && !isMoving)
        {
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = target.position;

        float distance = Vector3.Distance(startPosition, targetPosition);
        float duration = distance / moveSpeed;

        float timePassed = 0f;

        while (timePassed < duration)
        {
            float t = timePassed / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            timePassed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure accurate final position
        isMoving = false;
    }
}
