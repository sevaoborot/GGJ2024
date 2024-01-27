using UnityEngine;

public class MG03_HidingPlaceScript : MonoBehaviour
{
    bool isFullyInTrigger = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "hidingObject" && isAllDotsInTrigger(collision.GetComponent<PolygonCollider2D>().points))
        {
            isFullyInTrigger = true;
            Debug.Log("Fully in trigger!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "hidingObject")
        {
            isFullyInTrigger = false;
            Debug.Log("Not in trigger anymore");
        }
    }

    bool isAllDotsInTrigger(Vector2[] edgePoints)
    {
        foreach (var point in edgePoints)
        {
            Debug.Log(point);
            Vector2 currentPoint = new Vector2(transform.position.x, transform.position.y) + point;
            Collider2D pathCollider = Physics2D.OverlapPoint(currentPoint);
            if (pathCollider == null) return false;
        }
        return true;
    }
}
