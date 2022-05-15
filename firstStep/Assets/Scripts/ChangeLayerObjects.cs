using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerObjects : MonoBehaviour
{
    [SerializeField]
    private int changedLayer;

    [SerializeField]
    private GameObject[] things;

    private SpriteRenderer[] spriteRendererThings;

    private int defaultLayer;

    private void Start()
    {
        defaultLayer = spriteRendererThings[0].sortingOrder;

        for (int i = 0; i < things.Length; i++)
        {
            spriteRendererThings[i] = things[i].GetComponent<SpriteRenderer>();
        }
    }

    private void ChangeLayerObgect(int layer)
    {
        for (int i = 0; i < things.Length; i++)
        {
            spriteRendererThings[i].sortingOrder = layer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeLayerObgect(changedLayer);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeLayerObgect(defaultLayer);
    }

}
