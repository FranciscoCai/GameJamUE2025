using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class InitialFadeIn : MonoBehaviour
{
    public Image image;
    public float fadeDuration = 2f;
    void Start()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        Color startColor = image.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;
            image.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        image.color = endColor;
        gameObject.SetActive(false);
    }
}


