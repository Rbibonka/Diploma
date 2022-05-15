using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void Start()
    {
        int j = 9;
        for (int i = 1; i < j--; i++)
        {
        }
        Debug.Log(j);
    }
}
