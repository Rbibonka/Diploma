using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField]
    private string question;

    [SerializeField]
    private string[] incorrectAnswers;

    [SerializeField]
    private string correctAnswer;

    public string ReturnQuestion
    {
        get
        {
            return question;
        }
    }

    public string[] ReturnIncorrectAnswers
    {
        get
        {
            return incorrectAnswers;
        }
    }

    public string ReturnCorrectAnswer
    {
        get
        {
            return correctAnswer;
        }
    }
}
