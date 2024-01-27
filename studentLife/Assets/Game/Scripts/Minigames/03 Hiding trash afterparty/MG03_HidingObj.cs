using System;
using UnityEngine;

public class MG03_HidingObj : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Action OnInTrigger;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in collider");
        spriteRenderer.color = Color.green;
        OnInTrigger?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("not in collider");
        spriteRenderer.color = Color.white;
    }
}
