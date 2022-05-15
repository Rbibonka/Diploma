using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInput : MonoBehaviour
{
    [SerializeField]
    private InputField firstInput;

    [SerializeField]
    private InputField secondInput;

    [SerializeField]
    private GameObject correctAnswer;

    [SerializeField]
    private GameObject incorrectAnswer;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private string numberOne;

    [SerializeField]
    private string numberTwo;

    private IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(2f);

        correctAnswer.SetActive(false);

        incorrectAnswer.SetActive(false);

        mainPanel.SetActive(false);
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(2f);

        incorrectAnswer.SetActive(false);
    }

    public void CheckInputs()
    {
        if (firstInput.text == numberOne && secondInput.text == numberTwo)
        {
            correctAnswer.SetActive(true);

            StartCoroutine(WaitAndClose());
        }
        else
        {
            incorrectAnswer.SetActive(true);

            StartCoroutine(Close());
        }

        
    }
}
