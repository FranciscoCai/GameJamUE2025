using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BelugaOnTrack belugaOnTrack;

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
    }

    public void AddNote()
    {
        score++;
    }
    public void PowerUp(float amount)
    {
        cafeini += amount;
    }

    private void Update()
    {
        if(belugaOnTrack.onTrack)
        {
            cafeini = cafeini;
        }
        else
        {
            cafeini -= dropSpeed * Time.deltaTime;
        }
        cafeiniBar.fillAmount = cafeini/100f;
        bool isBoosting = boostAction.action.IsPressed();
        if (isBoosting)
        {
            cafeini -= dropBoost * Time.deltaTime;
        }
        if(cafeini<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
