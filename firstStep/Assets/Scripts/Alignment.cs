using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alignment : MonoBehaviour
{
    [SerializeField]
    private Transform center;

    private DragAndDrop dragAndDrop;

    private Transform textForAlign;

    private bool inTrigger = false;

    private int line;

    public int ReturnLine
    {
        get
        {
            return line;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TextAnswer"))
        {
            dragAndDrop = collision.GetComponent<DragAndDrop>();

            textForAlign = collision.GetComponent<Transform>();

            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;

        line = 0;
    }

    private void FixedUpdate()
    {
        if (inTrigger)
        {
            if (dragAndDrop.ReturnEndDrag)
            {
                textForAlign.position = center.position;

                line = dragAndDrop.ReturnNumberInString;
            }
        }
        else
        {
            line = 0;
        }
    }
}
