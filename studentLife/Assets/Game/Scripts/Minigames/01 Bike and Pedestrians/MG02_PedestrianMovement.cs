using UnityEngine;

public class MG02_PedestrianMovement : MonoBehaviour
{
    [SerializeField] Vector2 startPosition;
    [SerializeField] float desiredDuration;
    [SerializeField] float lerpDistance;
    
    float elapsedTime;
    Vector2 endPosition;

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
        if (transform.position == new Vector3(endPosition.x, endPosition.y, 0)) Destroy(this.gameObject); 
    }
}
