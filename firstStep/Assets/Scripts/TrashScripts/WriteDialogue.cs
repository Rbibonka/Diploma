using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteDialogue : MonoBehaviour
{
    [SerializeField]
    private Text speakerName;

    [SerializeField]
    private Text speakerText;

    [SerializeField]
    private GameObject panel;

    private bool nextText = false;

    private bool isTalking = true;

    private bool dialogActivity = true;

    public void WriteText(string nameSpeaker, string[] textSpeaker, string secondNameSpeaker)
    {
        if (dialogActivity)
        {
            dialogActivity = false;

            StartCoroutine(SlowWriteText(textSpeaker, nameSpeaker, secondNameSpeaker));
        }
        else
        {
            Debug.Log("///");
        }
    }

    public void NextSentence()
    {
        nextText = true;
    }

    private void ChangeSpeaker(string nameSpeaker, string secondNameSpeaker)
    {
        if (isTalking)
        {
            speakerName.text = nameSpeaker;

            isTalking = false;
        }
        else
        {
            speakerName.text = secondNameSpeaker;

            isTalking = true;
        }
    }

    private IEnumerator SlowWriteText(string[] mainText, string nameSpeaker, string secondNameSpeaker)
    {
        speakerName.text = nameSpeaker;

        speakerText.text = "";

        panel.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        for (int numberSecntce = 0; numberSecntce < mainText.Length; numberSecntce++)
        {
            ChangeSpeaker(nameSpeaker, secondNameSpeaker);

            speakerText.text = "";

            for (int numberLetter = 0; numberLetter < mainText[numberSecntce].Length; numberLetter++)
            {
                speakerText.text += mainText[numberSecntce][numberLetter];

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitUntil(() => nextText == true);

            nextText = false;
        }

        panel.SetActive(false);

        dialogActivity = true;

        yield break;
    }
}
