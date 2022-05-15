using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutMainCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject blackoutPanel;

    [SerializeField]
    private GameObject tipWindow;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = blackoutPanel.GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.material.color;

        color.a = 0f;

        spriteRenderer.material.color = color;
    }

    IEnumerator Blackout(Collider2D player)
    {
        for (float f = 0.05f; f <= 2; f += 0.05f)
        {
            Color color = spriteRenderer.material.color;

            color.a = f;

            spriteRenderer.material.color = color;

            if(f > 1f)
            { 


            }

            yield return new WaitForSeconds(0.05f);
        }

        NormalBrightness();

    }

    private void NormalBrightness()
    {
        Color color = spriteRenderer.material.color;

        color.a = 1f;

        spriteRenderer.material.color = color;

        blackoutPanel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        tipWindow.SetActive(true);

        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                blackoutPanel.SetActive(true);

                StartCoroutine(Blackout(collision));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tipWindow.SetActive(false);
    }
}
