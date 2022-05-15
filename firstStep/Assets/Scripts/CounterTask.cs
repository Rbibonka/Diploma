using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterTask : MonoBehaviour
{
    [SerializeField]
    private Text textTask;

    private int currentQuantityTask = 0;

    public int RuturnCurrentQuantityTask
    {
        get
        {
            return currentQuantityTask;
        }
    }

    private void Start()
    {
        ActivatorPanel.addingTask += UpdateTask;
    }

    private void OnDisable()
    {
        ActivatorPanel.addingTask -= UpdateTask;
    }

    private void UpdateTask()
    {
        currentQuantityTask++;

        textTask.text = $"{currentQuantityTask}/5";
    }
}
