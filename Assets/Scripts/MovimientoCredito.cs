using TMPro;
using UnityEngine;

public class MovimientoCredito : MonoBehaviour
{
    public class FloatingText : MonoBehaviour
    {
        public float moveSpeed = 20f;
        public float duration = 1.5f;

        private float timer = 0f;
        private RectTransform rectTransform;
        private TMP_Text tmpText;
        private Color originalColor;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            tmpText = GetComponent<TMP_Text>();
            originalColor = tmpText.color;
        }

        void Update()
        {
            // Subir el texto
            rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

            // Fade out
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / duration);
            tmpText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Destruir al terminar
            if (timer >= duration)
                Destroy(gameObject);
        }
    }
    }
