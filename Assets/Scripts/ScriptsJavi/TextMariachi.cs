using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TextMariachi : MonoBehaviour
{
    public TMP_Text textMeshPro;
    [TextArea]
    public string fullText;
    public float delay = 0.05f; // tiempo entre letras
    public float finalDelay = 0.05f; // tiempo entre letras
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(FadeOutAudio());
        StartCoroutine(ShowText());
    }
    private IEnumerator FadeOutAudio()
    {
        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < 2)
        {
            timer += Time.deltaTime;
            float t = timer / 2;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop(); // Opcional
        audioSource.volume = 0.5f;
    }
    private IEnumerator ShowText()
    {
        textMeshPro.text = ""; // Limpiar texto al inicio

        for (int i = 0; i <= fullText.Length; i++)
        {
            textMeshPro.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(3);
        yield return FadeOutCoroutine();
        SceneManager.LoadScene(1);
    }
    private IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        float duration = 3f;

        Color originalColor = textMeshPro.color;

        // Aseguramos que empiece con alpha 1
        textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

        // Fade OUT: alpha de 1 → 0
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / duration);
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Por si acaso, nos aseguramos de dejar el alpha a 0
        textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
