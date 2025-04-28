using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeTransition : MonoBehaviour
{
    public Image fadeImage; // Asigna aquí el PanelFade
    public float fadeDuration = 1.0f; // Duración del fade

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        // Asegúrate que el Panel esté visible
        fadeImage.gameObject.SetActive(true);

        // Fade In (oscurecer)
        Color color = fadeImage.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            color.a = t / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        // Asegura que esté completamente negro
        color.a = 1;
        fadeImage.color = color;

        // Cargar la escena
        SceneManager.LoadScene(sceneName);
    }
}
