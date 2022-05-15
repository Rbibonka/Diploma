using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesSpeakers : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteSpeaker;

    [SerializeField]
    private Sprite secondSpriteSpeaker;
    
    [TextArea()]
    [SerializeField]
    private string[] mainText;

    public Sprite SecondNameSpeaker
    {
        get
        {
            return secondSpriteSpeaker;
        }
    }

    public string[] MainText
    {
        get
        {
            return mainText;
        }
    }

    public Sprite NameSpeaker
    {
        get
        {
            return spriteSpeaker;
        }
    }
}
