using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class ConectaUnMando : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  
    public TextMeshProUGUI textMeshPro2;
    public GameObject MenuInicial;
    public float fadeSpeed = 1f;  
    private float alpha = 1f;          
    private bool fadingOut = true;  
    private float timeElapsed = 0f;  

    void Update()
    {
        // Acumular el tiempo transcurrido dentro del ciclo
        timeElapsed += Time.deltaTime;

        // Si el texto se está desvaneciendo (fade-out)
        if (fadingOut)
        {
            // Decrecer el alpha exponencialmente (decrece lentamente al principio y rápidamente al final)
            alpha = Mathf.Exp(-fadeSpeed * timeElapsed);  // Exponecial decreciente
            alpha = Mathf.Clamp01(alpha);  // Asegurarse de que el alpha esté entre 0 y 1

            // Si el alpha llega a 0, reinicia el fade (reset de alpha a 1)
            if (alpha <= 0.01f)
            {
                alpha = 1f;
                fadingOut = false;  // Cambiar el estado para comenzar a hacer fade-in
                timeElapsed = 0f;   // Reinicia el tiempo para el siguiente ciclo
            }
        }
        else
        {
            // Si no está desvaneciendo, entonces queremos volver al alpha máximo instantáneamente
            alpha = 1f;
            fadingOut = true;  // Cambiar a fade-out nuevamente
        }

        // Aplicar el alpha al texto de TextMeshPro
        Color currentColor = textMeshPro.color;
        currentColor.a = alpha;
        textMeshPro.color = currentColor;

        if (Gamepad.all.Count > 0)
        {
            // Si hay al menos un Gamepad conectado
            Debug.Log("Mando conectado.");
            StartCoroutine(CountdownCoroutine());  
        }
        else
        {
            // Si no hay Gamepad conectado
            Debug.Log("No hay mandos conectados.");
        }
    }

    private IEnumerator CountdownCoroutine()
    {
        float currentTime = 3f; 

        while (currentTime > 0)
        {
            textMeshPro2.text = Mathf.Ceil(currentTime).ToString();

            currentTime -= Time.deltaTime;
        }
        MenuInicial.SetActive(true);
        Destroy(gameObject);
        return null;
    }
}

