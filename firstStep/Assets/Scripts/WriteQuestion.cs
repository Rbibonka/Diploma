using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteQuestion : MonoBehaviour
{
    private int numberQuestion = 0;

    private Question[] questions;

    private int correctAnswer;

    private int counterIncorrectAnswers = 0;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private GameObject getQuestion;

    [SerializeField]
    private Text writeQuestion;

    [SerializeField]
    private Button[] incorrectAnswers;

    [SerializeField]
    private GameObject panelCorrectAnswer;

    [SerializeField]
    private GameObject panelIncorrectAnswer;

    private void Start()
    {
        questions = getQuestion.GetComponents<Question>();

        WritingQuestion();
    }

    private void WritingQuestion()
    {
        writeQuestion.text = questions[numberQuestion].ReturnQuestion;

        correctAnswer = Random.Range(0, 4);

        for (int i = 0; i < 4; i++)
        {
            if (i == correctAnswer)
            {
                incorrectAnswers[i].GetComponentInChildren<Text>().text = questions[numberQuestion].ReturnCorrectAnswer;
            }
            else
            {
                incorrectAnswers[i].GetComponentInChildren<Text>().text = questions[numberQuestion].ReturnIncorrectAnswers[counterIncorrectAnswers];
                
                if(counterIncorrectAnswers <= questions.Length)
                {
                    counterIncorrectAnswers++;
                }
            }
        }
    }

    IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(2f);

        panelCorrectAnswer.SetActive(false);

        panelIncorrectAnswer.SetActive(false);

        mainPanel.SetActive(false);
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(2f);

        panelIncorrectAnswer.SetActive(false);
    }

    public void CheckAnswer(int numberButton)
    {
        if (numberButton == correctAnswer)
        {
            StartCoroutine(WaitAndClose());

            panelCorrectAnswer.SetActive(true);
        }
        else
        {
            panelIncorrectAnswer.SetActive(true);
            StartCoroutine(Close());
        }
    }
}
