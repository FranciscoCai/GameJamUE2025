using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOver : MonoBehaviour
{
    public RawImage gameOverImage;
    public VideoPlayer videoPlayer;
    private bool loading = false;
    private void Update()
    {
        if(GameManager.Instance.cafeini <= 0 && !loading)
        {
            loading = true;
            StartVideopCorutine();
        }
    }
    private void StartVideopCorutine()
    {
        Time.timeScale = 0.3f;
        StartCoroutine(FadeOutCoroutine());
    }
    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        videoPlayer.enabled = true;
        float timer = 0f;
        Color originalColor = gameOverImage.color;
        originalColor.a = 0f;
        gameOverImage.color = originalColor;

        // Hacemos fade IN (el alpha va subiendo hasta 1)
        while (timer < .7f)
        {
            timer += Time.deltaTime*5f;
            float alpha = Mathf.Clamp01(timer);
            gameOverImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}
