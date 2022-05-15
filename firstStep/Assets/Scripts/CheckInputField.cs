using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInputField : MonoBehaviour
{
    [SerializeField]
    private GameObject incorrectPanel;

    [SerializeField]
    private GameObject correctPanel;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private string correctAnswer;

    public void CheckInput()
    {
        if (inputField.text == correctAnswer)
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

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(2f);

        incorrectPanel.SetActive(false);
    }

    private IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(2f);

        correctPanel.SetActive(false);

        mainPanel.SetActive(false);
    }
}
