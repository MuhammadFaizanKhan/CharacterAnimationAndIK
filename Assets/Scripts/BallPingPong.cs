using UnityEngine;

public class BallPingPong : MonoBehaviour
{

    public float moveDistanceHorizontal = 2f; // Distance to move left and right
    public float moveDistanceVertical = 1f;   // Distance to move up and down
    public float speed = 1f;                  // Movement speed

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveBall());
    }

    private System.Collections.IEnumerator MoveBall()
    {
        while (true)
        {
            // Move left
            yield return StartCoroutine(MoveToPosition(initialPosition + Vector3.left * moveDistanceHorizontal));
            // Move back to center
            yield return StartCoroutine(MoveToPosition(initialPosition));

            // Move up
            yield return StartCoroutine(MoveToPosition(initialPosition + Vector3.up * moveDistanceVertical));
            // Move down
            yield return StartCoroutine(MoveToPosition(initialPosition + Vector3.down * moveDistanceVertical));
            // Move back to center
            yield return StartCoroutine(MoveToPosition(initialPosition));
        }
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}

