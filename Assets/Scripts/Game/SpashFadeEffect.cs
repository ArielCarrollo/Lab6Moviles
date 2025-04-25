using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashFadeEffect : MonoBehaviour
{
    public Image fadeImage; // Asigna una imagen negra con alfa
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        yield return StartCoroutine(Fade(1f, 0f)); // Fade in
        yield return new WaitForSeconds(1f);        // Tiempo visible
        yield return StartCoroutine(Fade(0f, 1f)); // Fade out
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float t = 0f;
        Color c = fadeImage.color;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            c.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = c;
            yield return null;
        }
    }
}
