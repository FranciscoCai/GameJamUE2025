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

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        textMeshPro.text = ""; // Limpiar texto al inicio

        for (int i = 0; i <= fullText.Length; i++)
        {
            textMeshPro.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(finalDelay);
        SceneManager.LoadScene(2);
    }
}
