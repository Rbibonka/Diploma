using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ActivatorPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject table;

    [SerializeField]
    private GameObject sign;

    private bool exitIsTrigger = false;

    public static Action addingTask;

    IEnumerator WaitPressButton()
    {
        yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.E));

        if (exitIsTrigger)
        {
            yield break;
        }
        else
        {
            addingTask?.Invoke();

            table.SetActive(true);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        exitIsTrigger = false;

        StartCoroutine(WaitPressButton());

        sign.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitIsTrigger = true;

        sign.SetActive(false);
    }
}
