using UnityEngine;
using UnityEngine.Splines;

public class CinematicaSplines : MonoBehaviour
{
    public GameObject Mariachis;
    private SplineContainer splineContainer;
    public GameObject targetImage;
    public VueloDeBeluga vuelo;
    public Transform target;
    public float speed = 1f;


    private float t = 0f; // posición a lo largo del spline (0 a 1)
    private void Start()
    {
        splineContainer = GetComponent<SplineContainer>();
    }

    void Update()
    {
        if (splineContainer == null || splineContainer.Spline == null)
            return;

        t += speed * Time.deltaTime / splineContainer.CalculateLength();
        t = Mathf.Clamp01(t); // opcional, para no pasarte

        // Obtener posición y rotación del spline
        splineContainer.Evaluate(t, out var pos, out var tangent, out var up);

        target.position = pos;
        target.rotation = Quaternion.LookRotation(tangent, up);
        if (IsFinished())
        {
            vuelo.enabled = true;
            targetImage.SetActive(true);
            Mariachis.SetActive(true);
            Destroy(gameObject);
            GameManager.Instance.cafeini = 100;
        }
    }

    public bool IsFinished() => t >= 1f;
}
