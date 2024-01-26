using UnityEngine;

public class MG02_PedestrianMovement : MonoBehaviour
{
    Vector2 startPosition;
    Vector2 endPosition;
    float desiredDuration;
    float elapsedTime;
    float lerpDistance;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector2 (transform.position.x + lerpDistance, transform.position.y);
    }

    void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;
        float lerpComplete = elapsedTime / desiredDuration;
        transform.position = Vector2.Lerp(startPosition, endPosition, lerpComplete);
    }
}
