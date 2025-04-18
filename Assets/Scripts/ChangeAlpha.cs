using System.Collections;
using UnityEngine;

public class ChangeAlpha : MonoBehaviour
{
    public Renderer objectRenderer;
    public float fadeDuration = 2f;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();  
        Material mat = objectRenderer.material;
        StartCoroutine(FadeOutMaterial(mat, fadeDuration));
    }

    private IEnumerator FadeOutMaterial(Material mat, float duration)
    {
        Color color = mat.color;
        float startAlpha = color.a;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 1f, elapsed / duration);
            mat.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }

        mat.color = new Color(color.r, color.g, color.b, 1f);
    }
}
