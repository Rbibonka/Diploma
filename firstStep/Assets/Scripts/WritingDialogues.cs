using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingDialogues : MonoBehaviour
{
    [SerializeField]
    private Image speakerImage;

    [SerializeField]
    private Text speakerText;

    [SerializeField]
    private GameObject panel;

    private GameObject player;

    private MovingPlayer movingPlayer;

    private bool nextText = false;

    private bool isTalking = true;

    private bool dialogActivity = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        movingPlayer = player.GetComponent<MovingPlayer>();
    }

    public void WriteText(Sprite spriteSpeaker, string[] textSpeaker, Sprite secondSpriteSpeaker)
    {
        if (dialogActivity)
        {
            movingPlayer.enabled = false;

            dialogActivity = false;

            StartCoroutine(SlowWriteText(textSpeaker, spriteSpeaker, secondSpriteSpeaker));
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

    private void ChangeSpeaker(Sprite spriteSpeaker, Sprite secondSpriteSpeaker)
    {
        if (isTalking)
        {
            speakerImage.sprite = spriteSpeaker;

            isTalking = false;
        }
        else
        {
            speakerImage.sprite = secondSpriteSpeaker;

            isTalking = true;
        }
    }

    private IEnumerator SlowWriteText(string[] mainText, Sprite spriteSpeaker, Sprite secondSpriteSpeaker)
    {
        speakerImage.sprite = spriteSpeaker;

        speakerText.text = "";

        panel.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        for (int numberSecntce = 0; numberSecntce < mainText.Length; numberSecntce++)
        {
            ChangeSpeaker(spriteSpeaker, secondSpriteSpeaker);

            speakerText.text = "";

            for (int numberLetter = 0; numberLetter < mainText[numberSecntce].Length; numberLetter++)
            {
                speakerText.text += mainText[numberSecntce][numberLetter];

                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitUntil(() => nextText == true);

            nextText = false;
        }

        panel.SetActive(false);

        dialogActivity = true;

        movingPlayer.enabled = true;

        isTalking = true;

        yield break;
    }
}
