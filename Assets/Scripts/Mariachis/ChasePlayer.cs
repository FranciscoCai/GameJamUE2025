using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float detectionRadius = 15f;       
    public float moveSpeed = 5f;
    public MariachiMovement mariachiMovement;
    public Transform reespawn;

    public LayerMask detectionLayer;

    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Beluga");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        DetectPlayer();

        if (isChasing)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            mariachiMovement.enabled = false;

            if (Vector3.Distance(transform.position, player.position) < 7)
            {
                player.position = reespawn.position;
                GameManager.Instance.cafeini = GameManager.Instance.cafeini - 40;
            }
        }
        if(!isChasing)
        {
            mariachiMovement.enabled = true;
        }
    }

    void DetectPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

        isChasing = false;
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Beluga"))
            {
                isChasing = true;
                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}