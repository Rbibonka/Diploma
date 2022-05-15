using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayaer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private int defaultLayer;

    [SerializeField]
    private int numberLayer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        defaultLayer = spriteRenderer.sortingOrder;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sortingOrder = numberLayer;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sortingOrder = defaultLayer;
        }
    }
}
