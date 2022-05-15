using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswers : MonoBehaviour
{
    [SerializeField]
    private Alignment firstString;

    [SerializeField]
    private Alignment secondString;

    [SerializeField]
    private GameObject correctPanel;

    [SerializeField]
    private GameObject incorrectPanel;

    [SerializeField]
    private GameObject mainPanel;

    private int[] lines = new int[2];

    private IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(2f);

        mainPanel.SetActive(false);

        correctPanel.SetActive(false);

        incorrectPanel.SetActive(false);
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(2f);

        incorrectPanel.SetActive(false);
    }

    public void CheckLines()
    {
        lines[0] = firstString.ReturnLine;

        lines[1] = secondString.ReturnLine;

        if (lines[0] == 1 && lines[1] == 2)
        {
            correctPanel.SetActive(true);

            StartCoroutine(WaitAndClose());
        }
        else
        {
            incorrectPanel.SetActive(true);

            StartCoroutine(Close());
        }

    }
}
