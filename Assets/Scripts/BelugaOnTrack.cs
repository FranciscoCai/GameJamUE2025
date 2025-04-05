using UnityEngine;

public class BelugaOnTrack : MonoBehaviour
{
    public bool onTrack = false;
    public ParticleSystem particleSystem;
    public Color newColor = Color.red;
    public float detectionRadius = 15f;

    public Color originalColor;

    public LayerMask detectionLayer;

    private bool isTouchingPentagram = false;
    private float checkDelay = 0.1f;
    private float lastCheckTime = 0f;

    void Start()
    {
        if (particleSystem == null)
            particleSystem = GetComponent<ParticleSystem>();

        originalColor = particleSystem.main.startColor.color;
    }

    private void Update()
    {
        DetectPentagram();
    }
 
    void DetectPentagram()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        onTrack = false;
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Pentagram"))
            {
                ChangeParticleColor(newColor);
                onTrack = true;
                break;
            }
            else
            {
                ChangeParticleColor(originalColor);
            }
        }
    }
    private void ChangeParticleColor(Color color)
    {
        var main = particleSystem.main;
        main.startColor = color;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

