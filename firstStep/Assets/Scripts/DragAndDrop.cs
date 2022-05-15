using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private int numberInStirng;

    private bool endDrag = false;

    public int ReturnNumberInString 
    {
        get
        {
            return numberInStirng;
        }
    }

    public bool ReturnEndDrag
    {
        get
        {
            return endDrag;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        endDrag = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endDrag = true;
    }
}
