using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeImage : MonoBehaviour
{
    [SerializeField]
    private Sprite[] v;

    private SpriteRenderer spriteRenderer;

    private int i = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeImages()
    {
        if (i == 1)
        {
            spriteRenderer.sprite = v[0];
        }
        else
        {
            spriteRenderer.sprite = v[1];
            i++;
        }
        
    }
}
