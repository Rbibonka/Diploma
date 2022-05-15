using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit1 : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPointInRoom;

    private Transform playerTransform;

    private bool exitIsTrigger = false;

    IEnumerator WaitPressButton()
    {
        yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.E));

        if (exitIsTrigger)
        {
            yield break;
        }
        else
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            playerTransform.position = spawnPointInRoom.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        exitIsTrigger = false;

        StartCoroutine(WaitPressButton());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitIsTrigger = true;
    }
}
