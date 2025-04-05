using UnityEngine;

public class CambioCamaraUltimaNota : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Beluga"))
        {
            other.gameObject.GetComponent<VueloDeBeluga>().enabled = false;

        }
    }
}
