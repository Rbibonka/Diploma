using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceInRooms : MonoBehaviour
{
    [SerializeField]
    private CounterTask counterTask;

    [SerializeField]
    private GameObject dialogue;

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
            

            int quantityNumber = counterTask.RuturnCurrentQuantityTask;

            Debug.Log(quantityNumber);

            if (quantityNumber == 5)
            {
                playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

                playerTransform.position = spawnPointInRoom.position;
            }
            else
            {
                dialogue.SetActive(true);

                //dialogue.SetActive(false);
            }
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

        dialogue.SetActive(false);
    }
}
