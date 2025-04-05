using UnityEngine;

public class ColisionCambioCamaraUltimaNota : MonoBehaviour
{
    public CambioCamaraUltimaNota Camera;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Beluga"))
        {
            other.gameObject.transform.parent.GetComponent<VueloDeBeluga>().enabled = false;
            Camera.StartCoroutine(Camera.CambioCamara());
            Destroy(gameObject);
        }
    }
}
