using UnityEngine;
using UnityEngine.Splines;

public class CinematicaSplines : MonoBehaviour
{
    private SplineContainer splineContainer;
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
    }

    public bool IsFinished() => t >= 1f;
}
