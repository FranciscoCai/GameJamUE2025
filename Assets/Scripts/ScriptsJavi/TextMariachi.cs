using UnityEngine;
using System.Collections;
using TMPro;

public class TextMariachi : MonoBehaviour
{
    public TMP_Text textComponent;
    public float Speed;
    public string Context;
    private void Start()
    {
        StartCoroutine(TypeWords(Context));
    }
    private IEnumerator TypeWords(string fullText)
    {
        textComponent.text = "";
        string[] words = fullText.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            textComponent.text += words[i] + " ";
            yield return new WaitForSeconds(Speed);
        }
    }
}
