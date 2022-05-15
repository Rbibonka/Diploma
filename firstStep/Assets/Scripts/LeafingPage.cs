using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafingPage : MonoBehaviour
{
    private Animator[] animators;

    private int numberPage = 0;

    private bool nextPage = false;

    private Coroutine leafigPage;

    private void Start()
    {
        animators = GetComponentsInChildren<Animator>();

        numberPage = animators.Length - 1;

    }

    private void OnEnable()
    {
        leafigPage = StartCoroutine(LeafingNextPage());
    }

    private void OnDisable()
    {
        numberPage = animators.Length - 1;

        for (int i = 1; i < animators.Length; i++)
        {
            animators[i].SetTrigger("Default");
        }
    }

    IEnumerator LeafingNextPage()
    {
        while (true)
        {
            yield return new WaitUntil(() => nextPage == true);

            animators[numberPage].SetTrigger("Leaf");

            nextPage = false;

            numberPage--;

            if(numberPage < 1)
            {
                yield break;
            }
        }
    }

    public void NextPage()
    {
        nextPage = true;
    }
}
