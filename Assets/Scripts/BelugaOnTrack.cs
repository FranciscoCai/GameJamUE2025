using UnityEngine;

public class BelugaOnTrack : MonoBehaviour
{
    public bool onTrack = false;
    public ParticleSystem particleSystem;
    public Color newColor = Color.red;

    public Color originalColor;

    private bool isTouchingPentagram = false;
    private float checkDelay = 0.1f;
    private float lastCheckTime = 0f;

    void Start()
    {
        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();

        originalColor = particleSystem.main.startColor.color;
    }

    private void OnTriggerStay(Collider other)
    {
       if (other.CompareTag("Pentagram"))
        {
            Debug.Log(2);
            ChangeParticleColor(newColor);
            isTouchingPentagram = true;
            onTrack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pentagram"))
        {
            Debug.Log(4);
            ChangeParticleColor(originalColor);
            isTouchingPentagram = false;
            onTrack = false;
        }
    }

    private void Update()
    {
        if (!isTouchingPentagram && Time.time - lastCheckTime > checkDelay)
        {
            ChangeParticleColor(originalColor);
            lastCheckTime = Time.time;
            onTrack = false;
            Debug.Log(5);
        }
    }

    private void ChangeParticleColor(Color color)
    {
        var main = particleSystem.main;
        main.startColor = color;
    }
}
