using UnityEngine;

public class MariachiMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 moveDirection;
    
    void Start()
    {
        moveDirection = Random.onUnitSphere;
        moveDirection.Normalize();

    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Nebulosa"))
        {
            Debug.Log(1);
            Vector3 normal = collision.contacts[0].normal;
            moveDirection = Vector3.Reflect(moveDirection, normal);
        }
    }
}
