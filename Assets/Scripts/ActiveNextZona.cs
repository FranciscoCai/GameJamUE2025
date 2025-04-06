using UnityEngine;

public class ActiveNextZona : MonoBehaviour
{
    [SerializeField] private GameObject pieceToActive;
    [SerializeField] private GameObject soundNoteToActive;
    public AudioNotas audioNotas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Beluga"))
        {
            pieceToActive.SetActive(true);
            if (soundNoteToActive != null)
            {
                soundNoteToActive.SetActive(true);
                audioNotas.PlayNota();
            }
            Destroy(gameObject);
        }
    }
}
