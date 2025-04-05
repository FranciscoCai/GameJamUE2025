using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public float dropSpeed;
    public float dropBoost;
    [Range(0,100)]public float cafeini;
    public Image cafeiniBar;
    public InputActionReference boostAction;
    public static GameManager Instance { get; set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void AddNote()
    {
        score++;
    }
    private void Update()
    {
        cafeini -= dropSpeed * Time.deltaTime;
        RectTransform rt = cafeiniBar.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(cafeini, rt.sizeDelta.y);
        bool isBoosting = boostAction.action.IsPressed();
        if (isBoosting)
        {
            cafeini += dropBoost * Time.deltaTime;
        }
    }
}
