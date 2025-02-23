using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutScene : MonoBehaviour {
    public Image uiImage;
    public float fadeDuration = 1f;
    public float displayTime = 2f;

    private void Start() {
        gameObject.SetActive(false);
    }
    public void StartCutScene() {
        
        gameObject.SetActive(true);
        if (uiImage == null)
            uiImage = GetComponent<Image>();
        Color tempColor = uiImage.color;
        tempColor.a = 0;
        uiImage.color = tempColor;

        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence() {
        yield return Fade(0f, 1f, fadeDuration); // Fade In
        yield return new WaitForSeconds(displayTime); // Stay visible
        yield return Fade(1f, 0f, fadeDuration); // Fade Out
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration) {
        float elapsedTime = 0f;
        Color color = uiImage.color;
        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            uiImage.color = color;
            yield return null;
        }
        color.a = endAlpha;
        uiImage.color = color;
    }
}