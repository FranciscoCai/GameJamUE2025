using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PulsaStart : MonoBehaviour
{
    public InputActionReference boostAction;
    private bool loading = false;

    public GameObject targetObject;    
    public float blinkInterval = 0.5f;  
    public Image image; 

    private Coroutine blinkCoroutine;

    void Start()
    {
        blinkCoroutine = StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            targetObject.SetActive(!targetObject.activeSelf);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // Llama a esto si quieres cambiar la velocidad del parpadeo en tiempo real
    public void UpdateBlinkInterval(float newInterval)
    {
        blinkInterval = newInterval;

        // Reinicia la corutina para aplicar el nuevo intervalo inmediatamente
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }
        blinkCoroutine = StartCoroutine(BlinkRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        bool isPressing = boostAction.action.IsPressed();
        if (isPressing && !loading)
        {
            loading = true;
            UpdateBlinkInterval(0.1f);
            StartCoroutine(FadeOutCoroutine());
        }
    }
    private IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;

        Color originalColor = image.color;
        originalColor.a = 0f;
        image.color = originalColor;

        // Hacemos fade IN (el alpha va subiendo hasta 1)
        while (timer < 3f)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / 3);
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        SceneManager.LoadScene(2);
    }
}
