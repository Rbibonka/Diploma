using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueOne;

    [SerializeField]
    private GameObject dialogueTwo;

    [SerializeField]
    private GameObject exitOne;

    [SerializeField]
    private GameObject exitTwo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueOne.SetActive(false);

        dialogueTwo.SetActive(true);

        exitOne.SetActive(false);

        exitTwo.SetActive(true);

        Destroy(gameObject);
    }
}
