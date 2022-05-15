using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorDialogue : MonoBehaviour
{
    private enum TypeActivation
    {
        PressButton,
        InTrigger
    }

    [SerializeField]
    private TypeActivation typeActivation;

    private GameObject writingDialogue;

    private string[] speakerText;

    private string speakerName;

    private string secondNameSpeaker;

    PropertiesSpeaker propertiesSpeaker;

    WriteDialogue writeObjectText;

    private void Start()
    {
        propertiesSpeaker = GetComponent<PropertiesSpeaker>();

        writingDialogue = GameObject.FindGameObjectWithTag("Dialogue");

        writeObjectText = writingDialogue.GetComponent<WriteDialogue>();
    }

    private void StartDialogue()
    {
        speakerName = propertiesSpeaker.NameSpeaker;

        speakerText = propertiesSpeaker.MainText;

        secondNameSpeaker = propertiesSpeaker.SecondNameSpeaker;

        writeObjectText.WriteText(speakerName, speakerText, secondNameSpeaker);
    }

    IEnumerator WaitPressButton()
    {
        yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.E));

        StartDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (typeActivation == TypeActivation.PressButton)
        {
            StartCoroutine(WaitPressButton());
        }
        else if(typeActivation == TypeActivation.InTrigger)
        {
            StartDialogue();
        }
    }
}
