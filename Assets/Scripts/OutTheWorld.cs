using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class OutTheWorld : MonoBehaviour
{
    public float radius = 40f;
    public float maxDistance = 0.001f;
    public LayerMask layerMask;
    public Image canvasImage; // referencia a la imagen del Canvas
    public Transform SpawnPoint;
    public TMP_Text myText;

    void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(gameObject.transform.position, radius, Vector3.up,maxDistance, layerMask);

        float minDistance = Mathf.Infinity;

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                Vector3 closestPoint = hit.collider.ClosestPoint(gameObject.transform.position);
                float distance = Vector3.Distance(transform.position, closestPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }

            // Calcula qu¨¦ tan cerca est¨¢ con relaci¨®n al "radius"
            float proximity = Mathf.Clamp01(1 - (minDistance / radius));
            // Ajusta el alpha
            Color color = canvasImage.color;
            color.a = proximity;
            canvasImage.color = color;

            Color t_Color = myText.color;
            t_Color.a = proximity; // valor entre 0 (transparente) y 1 (opaco)
            myText.color = t_Color;
        }
        else
        {
            // Si no detecta nada, baja el alpha a 0
            Color color = canvasImage.color;
            color.a = 0f;
            canvasImage.color = color;

            Color t_Color = myText.color;
            t_Color.a = 0f; // valor entre 0 (transparente) y 1 (opaco)
            myText.color = t_Color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nebulosa"))
        {
            gameObject.transform.position = SpawnPoint.position;
            gameObject.transform.rotation = SpawnPoint.rotation;
        }
    }
}
