using UnityEngine;
using System.Collections;

public class FadeInCaminos : MonoBehaviour
{
    public Renderer objectRenderer;
    public float fadeDuration = 7f;
    void Start()
    {
        Material mat = objectRenderer.material;
        StartCoroutine(FadeOutMaterial(mat, fadeDuration));
    }

    // Update is called once per frame
    void Update()
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
            float newAlpha = Mathf.Lerp(startAlpha, 1f, elapsed / duration);
            mat.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }
    }
}
