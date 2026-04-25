// Final
// DIG 3878
// Celine Hui
// This script shows a typewriter animation for the narrative. 

using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class TypewriterText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float delayCharacter = 0.05f;
    
    [SerializeField] public CanvasGroup startButton;
    [SerializeField] private float buttonDuration = 1f;

    private Coroutine typingCoroutine;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        startButton.alpha = 0f;
        startButton.interactable = false;
        startButton.blocksRaycasts = false;
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        fadeCoroutine = StartCoroutine(TypeText());
    }


    private IEnumerator FadeInButton()
    {
        float time = 0f;

        while (time <= buttonDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / buttonDuration);
            startButton.alpha = Mathf.SmoothStep(0f, 1f, t);
            yield return null;
        }

        startButton.alpha = 1f;
        startButton.interactable = true;
        startButton.blocksRaycasts = true;
    }


    private IEnumerator TypeText()
    {   
        textComponent.maxVisibleCharacters = 0;

        for (int i = 0; i <= textComponent.text.Length; i++)
        {
            textComponent.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delayCharacter);
        }

        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(FadeInButton());
    }

}
