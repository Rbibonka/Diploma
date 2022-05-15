using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesSpeaker : MonoBehaviour
{
    [SerializeField]
    private string nameSpeaker;

    [SerializeField]
    private string secondNameSpeaker;

    [SerializeField]
    private string[] mainText;

    public string SecondNameSpeaker
    {
        get
        {
            return secondNameSpeaker;
        }
    }

    public string[] MainText
    {
        get
        {
            return mainText;
        }
    }

    public string NameSpeaker
    {
        get
        {
            return nameSpeaker;
        }
    }
}
