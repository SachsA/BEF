using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private float spriteBlinkingTimer = 1.0f;
    private float spriteBlinkingMiniDuration = 0.6f;
    private bool isClicked = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (!isClicked)
            SpriteBlinkingEffect();

    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}