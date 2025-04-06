using UnityEngine;
using System.Collections;
using TMPro;

public class GameOverFadeIn : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text text2;
    public TMP_Text text3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    // Update is called once per frame
    private IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;

        Color originalColor = text.color;
        originalColor.a = 0f;
        text.color = originalColor;

        // Hacemos fade IN (el alpha va subiendo hasta 1)
        while (timer < 3f)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / 3);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            text2.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            text3.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
    }
}
