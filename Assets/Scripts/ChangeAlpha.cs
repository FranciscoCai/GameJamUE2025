using System.Collections;
using UnityEngine;

public class ChangeAlpha : MonoBehaviour
{
    public Renderer objectRenderer;
    public float fadeDuration = 2f;

    void Start()
    {
        Material mat = objectRenderer.material;
        SetMaterialToTransparent(mat);
        StartCoroutine(FadeOutMaterial(mat, fadeDuration));
    }

    void SetMaterialToTransparent(Material mat)
    {

    }

    private IEnumerator FadeOutMaterial(Material mat, float duration)
    {
        Color color = mat.color;
        float startAlpha = color.a;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsed / duration);
            mat.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }

        mat.color = new Color(color.r, color.g, color.b, 0f);
    }
}
