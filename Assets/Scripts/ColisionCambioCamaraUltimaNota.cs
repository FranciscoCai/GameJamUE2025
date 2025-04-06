using UnityEngine;

public class ColisionCambioCamaraUltimaNota : MonoBehaviour
{
    public CambioCamaraUltimaNota Camera;
    public GameObject mariachis;
    public AdioManager audioManager; // Referencia al AudioManager
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Beluga"))
        {
            other.gameObject.transform.parent.GetComponent<VueloDeBeluga>().enabled = false;
            Camera.StartCoroutine(Camera.CambioCamara());
            Destroy(gameObject);
            mariachis.SetActive(false);
            audioManager.enabled = true;
        }
    }
}
