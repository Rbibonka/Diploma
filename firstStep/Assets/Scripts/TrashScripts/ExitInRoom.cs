using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitInRoom : MonoBehaviour
{
    [SerializeField]
   // private RoomThatOut.Rooms room;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<RoomThatOut>().ChangeRoomThatOut(room);
        }
    }
}
