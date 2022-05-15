using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorDialogues : MonoBehaviour
{
    private enum TypeActivation
    {
        PressButton,
        InTrigger
    }

    private enum TypeMultyple 
    { 
        Multyple,
        NotMultyple
    }

    [SerializeField]
    private TypeActivation typeActivation;

    [SerializeField]
    private TypeMultyple typeMultyple;

    [SerializeField]
    private GameObject sign;

    private GameObject writingDialogue;

    private string[] speakerText;

    private Sprite speakerName;

    private Sprite secondNameSpeaker;

    PropertiesSpeakers propertiesSpeakers;

    WritingDialogues writeObjectText;

    private bool exitIsTrigger = false;

    private void Start()
    {
        propertiesSpeakers = GetComponent<PropertiesSpeakers>();

        writingDialogue = GameObject.FindGameObjectWithTag("Dialogues");

        writeObjectText = writingDialogue.GetComponent<WritingDialogues>();
    }

    private void StartDialogue()
    {
        speakerName = propertiesSpeakers.NameSpeaker;

        speakerText = propertiesSpeakers.MainText;

        secondNameSpeaker = propertiesSpeakers.SecondNameSpeaker;

        writeObjectText.WriteText(speakerName, speakerText, secondNameSpeaker);
    }

    IEnumerator WaitPressButton()
    {
        yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.E));
        if (exitIsTrigger)
        {
            yield break;
        }
        else
        {
            StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        exitIsTrigger = false;

        sign.SetActive(true);

        if (typeActivation == TypeActivation.PressButton)
        {
            StartCoroutine(WaitPressButton());
        }
        else if (typeActivation == TypeActivation.InTrigger)
        {
            StartDialogue();
        }

        if (typeMultyple == TypeMultyple.NotMultyple)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitIsTrigger = true;

        sign.SetActive(false);
    }
}
