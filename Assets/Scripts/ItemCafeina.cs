using UnityEngine;

public class ItemCafeina : MonoBehaviour
{
    [SerializeField] private float amount;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Beluga"))
        {
            GameManager.Instance.PowerUp(amount);
            GameManager.Instance.lata.Play();
            Destroy(gameObject);
        }

    }
}
